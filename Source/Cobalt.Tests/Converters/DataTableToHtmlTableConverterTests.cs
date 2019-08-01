using Cobalt.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cobalt.Tests.Converters
{
    public class DataTableToHtmlTableConverterTests
    {
        [Fact]
        public void TestA()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("referenceid", typeof(int));
            dataTable.Columns.Add("text", typeof(string));
            dataTable.Columns.Add("amount", typeof(double));
            dataTable.Columns.Add("isactive", typeof(bool));
            dataTable.Columns.Add("intasbool", typeof(int));

            dataTable.Rows.Add(1000, 888, "Pannkaka", 25.83, true, 1);
            dataTable.Rows.Add(1001, 889, "Våfflor", 54.00, false, 0);
            dataTable.Rows.Add(1002, 890, "Plättar", 37.00, false, 0);

            var sut = new DataTableToHtmlTableConverter(dataTable).
                Convert();

            var fileTemplate = @"C:\Users\local.admin\Desktop\html-mall.html";
            var fileName = @"C:\Users\local.admin\Desktop\rapport.html";
            var fileContent = File.ReadAllText(fileTemplate);

            fileContent = fileContent.Replace("<--content-->", sut);

            File.WriteAllText(fileName, fileContent);
        }


    }
}
