using Dapper;
using Entities.UIConfigs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHangOnline.DataAccess;

namespace DataAccess.UIConfigs
{
    public class SysComboboxDAL : BaseDAL
    {
        #region --- sql string ---
        private const string SQL_GetComboById = @"
        SELECT CombobxId, ValueMember, DisplayMember, StoredDataLoad, TextDataLoad, IsUseText
        FROM tb_SysCombobox WHERE ComboboxId = @ComboboxId
";
        private const string SQL_GetFieldsComboByComboId = @"
        SELECT FieldId, FieldName, IsVisible, DataType, ComboboxId 
        FROM tb_SysFieldCombobox WHERE ComboboxId = @ComboboxId
";
        #endregion

        public SysCombobox GetComboboxById(string comboboxId)
        {
            SysCombobox item = new SysCombobox();
            try
            {
                Connection.Open();
                item = Connection.QuerySingleOrDefault<SysCombobox>(SQL_GetComboById, new { ComboboxId = comboboxId }, commandType: CommandType.Text);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return item;
        }

        public List<SysFieldCombobox> GetFieldsComboByComboId(string comboboxId) 
        {
            List<SysFieldCombobox> items = new List<SysFieldCombobox>();
            try
            {
                Connection.Open();
                items = Connection.Query<SysFieldCombobox>(SQL_GetFieldsComboByComboId, new { ComboboxId = comboboxId }, commandType: CommandType.Text).ToList();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return items;
        }
    }
}
