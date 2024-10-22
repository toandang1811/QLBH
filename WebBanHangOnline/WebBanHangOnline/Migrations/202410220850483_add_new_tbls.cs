namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_new_tbls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Employees",
                c => new
                    {
                        EmployeeId = c.String(nullable: false, maxLength: 50),
                        UserId = c.String(nullable: false, maxLength: 128),
                        EmployeeName = c.String(nullable: false, maxLength: 100),
                        BirthDay = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Modifiedby = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tb_Modules",
                c => new
                    {
                        ModuleId = c.String(nullable: false, maxLength: 128),
                        ModuleName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Orders = c.Int(nullable: false),
                        ParentId = c.String(),
                        Url = c.String(),
                        Icon = c.String(),
                        IsSideBar = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleId);
            
            CreateTable(
                "dbo.tb_Permissions",
                c => new
                    {
                        PermissionId = c.String(nullable: false, maxLength: 128),
                        ModuleId = c.String(nullable: false, maxLength: 128),
                        PermissionName = c.String(),
                    })
                .PrimaryKey(t => new { t.PermissionId, t.ModuleId })
                .ForeignKey("dbo.tb_Modules", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.tb_RolePermissions",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        PermissionId = c.String(nullable: false, maxLength: 128),
                        ModuleId = c.String(nullable: false, maxLength: 128),
                        Role_UserId = c.String(maxLength: 128),
                        Role_RoleId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.PermissionId, t.ModuleId })
                .ForeignKey("dbo.tb_Permissions", t => new { t.PermissionId, t.ModuleId }, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUserRoles", t => new { t.Role_UserId, t.Role_RoleId })
                .Index(t => new { t.PermissionId, t.ModuleId })
                .Index(t => new { t.Role_UserId, t.Role_RoleId });
            
            CreateTable(
                "dbo.tb_UserPermissions",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        PermissionId = c.String(nullable: false, maxLength: 128),
                        ModuleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.PermissionId, t.ModuleId })
                .ForeignKey("dbo.tb_Permissions", t => new { t.PermissionId, t.ModuleId }, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => new { t.PermissionId, t.ModuleId });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_UserPermissions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.tb_UserPermissions", new[] { "PermissionId", "ModuleId" }, "dbo.tb_Permissions");
            DropForeignKey("dbo.tb_RolePermissions", new[] { "Role_UserId", "Role_RoleId" }, "dbo.AspNetUserRoles");
            DropForeignKey("dbo.tb_RolePermissions", new[] { "PermissionId", "ModuleId" }, "dbo.tb_Permissions");
            DropForeignKey("dbo.tb_Permissions", "ModuleId", "dbo.tb_Modules");
            DropForeignKey("dbo.tb_Employees", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.tb_UserPermissions", new[] { "PermissionId", "ModuleId" });
            DropIndex("dbo.tb_UserPermissions", new[] { "UserId" });
            DropIndex("dbo.tb_RolePermissions", new[] { "Role_UserId", "Role_RoleId" });
            DropIndex("dbo.tb_RolePermissions", new[] { "PermissionId", "ModuleId" });
            DropIndex("dbo.tb_Permissions", new[] { "ModuleId" });
            DropIndex("dbo.tb_Employees", new[] { "UserId" });
            DropTable("dbo.tb_UserPermissions");
            DropTable("dbo.tb_RolePermissions");
            DropTable("dbo.tb_Permissions");
            DropTable("dbo.tb_Modules");
            DropTable("dbo.tb_Employees");
        }
    }
}
