using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.IO;

[Serializable]
[SqlUserDefinedAggregate(
    Format.UserDefined,
    IsInvariantToNulls = true,
    IsInvariantToDuplicates = false,
    IsInvariantToOrder = false,
    MaxByteSize = 8000)
]
public class Concat : IBinarySerialize
{
    StringBuilder result;
    public void Init()
    {
        result = new StringBuilder();
    }

    public void Accumulate(SqlString input)
    {
        if (input.IsNull)
        {
            return;
        }

        this.result.AppendFormat("{0}, ", input);
    }

    public void Merge(Concat objToMerge)
    {
        this.result.Append(objToMerge.result);
    }

    public SqlString Terminate()
    {
        string output = string.Empty;
        if (result != null && result.Length > 0)
        {
            result.Length -= 2;
            output = result.ToString();
        }

        return new SqlString(output);
    }
    
    public void Read(BinaryReader reader)
    {
        result = new StringBuilder(reader.ReadString());
    }

    public void Write(BinaryWriter writer)
    {
        writer.Write(this.result.ToString());
    }
}

