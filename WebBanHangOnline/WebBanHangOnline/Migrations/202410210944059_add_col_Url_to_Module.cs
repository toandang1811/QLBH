namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_col_Url_to_Module : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Modules", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Modules", "Url");
        }
    }
}
