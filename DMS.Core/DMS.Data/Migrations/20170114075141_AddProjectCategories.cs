using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

namespace DMS.Data.Migrations
{
    public partial class AddProjectCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("insert into dbo.ProjectCategory(CreatedBy, CreatedDateUtc, Description, LastUpdatedBy, LastUpdatedDateUtc, ShortDescription) values(0, '2017-1-14', 'Financial aid for educational purpose', 0, '2017-1-14', 'Education')");
            sql.AppendLine("update dbo.Projects set ProjectCategoryId=(select Id from dbo.ProjectCategory where ShortDescription='Education')");

            migrationBuilder.Sql(sql.ToString());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("update dbo.Projects set ProjectCategoryId=null");
            sql.AppendLine("delete dbo.ProjectCategory where ShortDescription='Education'");
            
            migrationBuilder.Sql(sql.ToString());
        }
    }
}
