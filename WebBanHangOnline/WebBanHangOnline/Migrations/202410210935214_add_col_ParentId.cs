namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_col_ParentId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Modules", "ParentId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Modules", "ParentId");
        }
    }
}
