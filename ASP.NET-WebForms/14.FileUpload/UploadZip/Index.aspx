<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="UploadZip.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/kendo.common.min.css" rel="stylesheet" />
    <link href="styles/kendo.default.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.0.3.js"></script>
    <script src="Scripts/kendo.web.js"></script>

</head>
<body>
    <input name="uploaded" id="uploaded" type="file" runat="server" />

    <div runat="server" id="uploadedStuff">
        <%= FileOutput %>
    </div>

    <script>
        function onUpload(e) {
            var files = e.files;
            $.each(files, function () {
                if (this.extension.toLowerCase() != ".zip") {
                    alert("Only .zip files can be uploaded");
                    e.preventDefault();
                }
            });
        }

        $(document).ready(function () {
            $("#uploaded").kendoUpload({
                async: {
                    saveUrl: "Upload.aspx",
                    autoUpload: true,
                },
                upload: onUpload
            });
        });
    </script>
</body>
</html>
