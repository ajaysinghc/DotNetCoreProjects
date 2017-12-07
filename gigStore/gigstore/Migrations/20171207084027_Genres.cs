using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace gigstore.Migrations
{
    public partial class Genres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Genres (Id, Name) values (1, 'Jazz')");
            migrationBuilder.Sql("Insert into Genres (Id, Name) values (2, 'Rock')");
            migrationBuilder.Sql("Insert into Genres (Id, Name) values (3, 'Blue')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Genres where Id in (1,2,3)");

        }
    }
}
