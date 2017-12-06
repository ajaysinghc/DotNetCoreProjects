using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace gigstore.Data.Migrations
{
    public partial class PopulateGenres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into genres(Id,name) values (1,'Jazz')");
             migrationBuilder.Sql("Insert into genres(Id, name) values (2, 'Blues')");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
