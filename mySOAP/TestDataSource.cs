using System;
using System.Data;

namespace mySOAP
{
    public static class TestDataSource
    {
        public static DataTable DataTable { get; private set; }

        static TestDataSource()
        {
            DataTable = new DataTable();
            DataTable.Columns.Add("BODS_Id", typeof(Guid)).AllowDBNull = false;
            DataTable.Columns.Add("BODS_FullName", typeof(string)).AllowDBNull = false;
            DataTable.Columns.Add("BODS_Status", typeof(byte)).AllowDBNull = false;
            DataTable.PrimaryKey = new[] { DataTable.Columns[0] };
            DataTable.Rows.Add(new Guid("617dba9d-391b-4ca7-aeeb-0703ca526709"), "My Website", 1);
            DataTable.Rows.Add(new Guid("bee3c0be-ccbf-4882-ad5a-d288f5677a51"), "Test V3 Offload", 2);
            DataTable.Rows.Add(new Guid("5df458a8-a743-4e81-bf0d-bd874f6f0cd3"), "About Australia", 3);
            DataTable.AcceptChanges();
        }
    }

}