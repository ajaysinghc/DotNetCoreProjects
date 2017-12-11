using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace gigstore.Migrations
{
    public partial class sqlite_Genre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Genres(Id, Name ) values(1 , 'Rock')");
            migrationBuilder.Sql("Insert into Genres(Id, Name ) values(2 , 'Jazz')");
            migrationBuilder.Sql("Insert into Genres(Id, Name ) values(3 , 'Blues')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
