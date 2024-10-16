namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Permissions",
                c => new
                    {
                        PermissionId = c.Int(nullable: false, identity: true),
                        PermissionName = c.String(),
                    })
                .PrimaryKey(t => t.PermissionId);
            
            CreateTable(
                "dbo.tb_UserPermissions",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.PermissionId })
                .ForeignKey("dbo.tb_Permissions", t => t.PermissionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.PermissionId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_UserPermissions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.tb_UserPermissions", "PermissionId", "dbo.tb_Permissions");
            DropIndex("dbo.tb_UserPermissions", new[] { "User_Id" });
            DropIndex("dbo.tb_UserPermissions", new[] { "PermissionId" });
            DropTable("dbo.tb_UserPermissions");
            DropTable("dbo.tb_Permissions");
        }
    }
}
