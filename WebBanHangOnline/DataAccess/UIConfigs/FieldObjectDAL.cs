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
    public class FieldObjectDAL : BaseDAL
    {
        #region -- str sql --
        private const string SQL_GetColumnObject = @"
        SELECT A.ObjectId, A.FieldId, A.FieldName, A.LanguageId, A.Description, A.IsColumn, A.IsVisible, A.Orders, A.IsPrimaryKey, A.DataType, B.Value AS DataTypeName
        FROM tb_FieldObject A
        LEFT JOIN tb_SysTypeInput B ON B.ID = A.DataType AND B.ValueType = 'DataTypeColumnGrid'
        WHERE ObjectId = @ObjectId
";
        #endregion

        public List<FieldObject> GetColumnObject(string objectId)
        {
            List<FieldObject> items = new List<FieldObject>();
            try
            {
                Connection.Open();
                items = Connection.Query<FieldObject>(SQL_GetColumnObject, new { ObjectId = objectId }, commandType: CommandType.Text).ToList();
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
