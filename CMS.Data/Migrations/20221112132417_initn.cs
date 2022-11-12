using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Data.Migrations
{
    public partial class initn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_AspNetUsers_OwnerId",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_Email_AspNetUsers_UserId",
                table: "Email");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_AspNetUsers_UserId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_AuthorId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Category_CategoryId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_PostAttachment_Post_PostId",
                table: "PostAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_AspNetUsers_PublishedById",
                table: "Track");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_Category_CategoryId",
                table: "Track");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Track",
                table: "Track");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostAttachment",
                table: "PostAttachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Email",
                table: "Email");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advertisement",
                table: "Advertisement");

            migrationBuilder.RenameTable(
                name: "Track",
                newName: "Tracks");

            migrationBuilder.RenameTable(
                name: "PostAttachment",
                newName: "PostAttachments");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "Email",
                newName: "Emails");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Advertisement",
                newName: "Advertisements");

            migrationBuilder.RenameIndex(
                name: "IX_Track_PublishedById",
                table: "Tracks",
                newName: "IX_Tracks_PublishedById");

            migrationBuilder.RenameIndex(
                name: "IX_Track_CategoryId",
                table: "Tracks",
                newName: "IX_Tracks_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_PostAttachment_PostId",
                table: "PostAttachments",
                newName: "IX_PostAttachments_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_CategoryId",
                table: "Posts",
                newName: "IX_Posts_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_AuthorId",
                table: "Posts",
                newName: "IX_Posts_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_UserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Email_UserId",
                table: "Emails",
                newName: "IX_Emails_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisement_OwnerId",
                table: "Advertisements",
                newName: "IX_Advertisements_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tracks",
                table: "Tracks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostAttachments",
                table: "PostAttachments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emails",
                table: "Emails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advertisements",
                table: "Advertisements",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ContentChangeLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ChangeAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Old = table.Column<int>(type: "int", nullable: false),
                    New = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentChangeLogs", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_AspNetUsers_OwnerId",
                table: "Advertisements",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_AspNetUsers_UserId",
                table: "Emails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostAttachments_Posts_PostId",
                table: "PostAttachments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_AspNetUsers_PublishedById",
                table: "Tracks",
                column: "PublishedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Categories_CategoryId",
                table: "Tracks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_AspNetUsers_OwnerId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_AspNetUsers_UserId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_PostAttachments_Posts_PostId",
                table: "PostAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_AspNetUsers_PublishedById",
                table: "Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Categories_CategoryId",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "ContentChangeLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tracks",
                table: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostAttachments",
                table: "PostAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emails",
                table: "Emails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advertisements",
                table: "Advertisements");

            migrationBuilder.RenameTable(
                name: "Tracks",
                newName: "Track");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "PostAttachments",
                newName: "PostAttachment");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notification");

            migrationBuilder.RenameTable(
                name: "Emails",
                newName: "Email");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Advertisements",
                newName: "Advertisement");

            migrationBuilder.RenameIndex(
                name: "IX_Tracks_PublishedById",
                table: "Track",
                newName: "IX_Track_PublishedById");

            migrationBuilder.RenameIndex(
                name: "IX_Tracks_CategoryId",
                table: "Track",
                newName: "IX_Track_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CategoryId",
                table: "Post",
                newName: "IX_Post_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorId",
                table: "Post",
                newName: "IX_Post_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_PostAttachments_PostId",
                table: "PostAttachment",
                newName: "IX_PostAttachment_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notification",
                newName: "IX_Notification_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_UserId",
                table: "Email",
                newName: "IX_Email_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisements_OwnerId",
                table: "Advertisement",
                newName: "IX_Advertisement_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Track",
                table: "Track",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostAttachment",
                table: "PostAttachment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Email",
                table: "Email",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advertisement",
                table: "Advertisement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_AspNetUsers_OwnerId",
                table: "Advertisement",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Email_AspNetUsers_UserId",
                table: "Email",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_AspNetUsers_UserId",
                table: "Notification",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_AuthorId",
                table: "Post",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Category_CategoryId",
                table: "Post",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostAttachment_Post_PostId",
                table: "PostAttachment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_AspNetUsers_PublishedById",
                table: "Track",
                column: "PublishedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Category_CategoryId",
                table: "Track",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
