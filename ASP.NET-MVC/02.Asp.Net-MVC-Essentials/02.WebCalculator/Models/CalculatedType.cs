using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02.WebCalculator.Models
{
    public enum CalculatedType
    {
        bit,
        Byte,
        Kilobit,
        Kilobyte,
        Megabit,
        Megabyte,
        Gigabit,
        Gigabyte,
        Terabit,
        Terabyte,
        Petabit,
        Petabyte,
        Exabit,
        Exabyte,
        Zettabit,
        Zettabyte,
        Yottabit,
        Yottabyte
    }
}
//<select name="type" onchange="change()">
//                        <option value="b">bit - b</option>
//                        <option value="B">Byte - B</option>
//                        <option value="Kb">Kilobit - Kb</option>
//                        <option value="KB">Kilobyte - KB</option>
//                        <option value="Mb">Megabit - Mb</option>
//                        <option value="MB" selected="selected">Megabyte - MB</option>
//                        <option value="Gb">Gigabit - Gb</option>
//                        <option value="GB">Gigabyte - GB</option>
//                        <option value="Tb">Terabit - Tb</option>
//                        <option value="TB">Terabyte - TB</option>
//                        <option value="Pb">Petabit - Pb</option>
//                        <option value="PB">Petabyte - PB</option>
//                        <option value="Eb">Exabit - Eb</option>
//                        <option value="EB">Exabyte - EB</option>
//                        <option value="Zb">Zettabit - Zb</option>
//                        <option value="ZB">Zettabyte - ZB</option>
//                        <option value="Yb">Yottabit - Yb</option>
//                        <option value="YB">Yottabyte - YB</option>
//                    </select>