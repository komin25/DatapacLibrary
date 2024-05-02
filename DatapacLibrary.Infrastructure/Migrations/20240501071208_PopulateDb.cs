﻿using DatapacLibrary.Domain;
using DatapacLibrary.Infrastructure.DbEntities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatapacLibrary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PopulateDb : Migration
    {
        

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            AddUsers(migrationBuilder);
            AddBooks(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM USERS", true);
            migrationBuilder.Sql("DELETE FROM BOOKS", true);
        }

        private void AddUsers(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 10; i++)
            {
                migrationBuilder.InsertData(
                    table: "Users", 
                    columns: ["Name", "Email", "Password", "Salt", "Created", "Updated"], 
                    values: [$"User{i}", $"user{i}@example.com", AuthenticationHelper.HashPassword($"Password{i}", out byte[] salt), salt, DateTime.UtcNow, DateTime.UtcNow]);

            }
        }

        private void AddBooks(MigrationBuilder migrationBuilder)
        {
            var rnd = new Random();
            for (int i = 1; i <= 50; i++)
            {
                migrationBuilder.InsertData(
                    table: "Books",
                    columns: ["Title", "Author", "Publisher", "PublicationYear", "ISBN", "NumberOfCopies", "Created", "Updated"],
                    values: [$"Title{i}", $"Author{i}", $"Publisher{i}", 1970 + i, $"ISBN{i}", rnd.Next(1, 6), DateTime.UtcNow, DateTime.UtcNow]);
            }
        }
    }
}
