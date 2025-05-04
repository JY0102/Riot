using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 전적검색
{
    internal class Database
    {
        private const string server_name = "DESKTOP-7AAHEAC";
        private const string db_name = "Riot";
        private const string sql_id = "home";
        private const string sql_pw = "jy3685";

        public DataSet ds { get; private set; } = new DataSet();
        private SqlDataAdapter RuneAdapter { get; set; } = new SqlDataAdapter();
        private SqlDataAdapter SpellAdapter { get; set; } = new SqlDataAdapter();

        public DataTable RuneTable { get => ds.Tables["rune"]; }
        public DataTable SpellTable { get => ds.Tables["spell"]; }

        public SqlConnection scon = null;

        public Database()
        {
            string con = string.Format($"Data Source={server_name};Initial Catalog={db_name};User ID={sql_id};Password={sql_pw}");
            scon = new SqlConnection(con);

            RuneAdapter.SelectCommand = RuneSelectAll();
            RuneAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            RuneAdapter.Fill(ds, "rune");

            SpellAdapter.SelectCommand = SpellSelectAll();
            SpellAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SpellAdapter.Fill(ds, "spell");

            RuneAdapter.InsertCommand = RuneInsert();
            RuneAdapter.DeleteCommand = RuneDelete();

            SpellAdapter.InsertCommand = SpellInsert();
            SpellAdapter.DeleteCommand = SpellDelete();
        }

        #region 룬 커맨드

        private SqlCommand RuneSelectAll()
        {
            string sql = "select * from rune";
            SqlCommand comm = new SqlCommand(sql, scon);
            return comm;
        }
        private SqlCommand RuneInsert()
        {
            string sql = "insert into rune values(@perk_id, @perk_icon, @perk_kor_name);";
            SqlCommand comm = new SqlCommand(sql, scon);
            comm.Parameters.Add("@perk_id", SqlDbType.Int, sizeof(int), "perk_id");
            comm.Parameters.Add("@perk_icon", SqlDbType.VarChar, 150, "perk_icon");
            comm.Parameters.Add("@perk_kor_name", SqlDbType.VarChar, 50, "perk_kor_name");
            return comm;
        }
        private SqlCommand RuneDelete()
        {
            string sql = "Delete from rune where perk_id = @perk_id;";
            SqlCommand comm = new SqlCommand(sql, scon);

            comm.Parameters.Add("@perk_id", SqlDbType.Int, 4, "perk_id");

            return comm;
        }
        #endregion

        #region 스펠 커맨드

        private SqlCommand SpellSelectAll()
        {
            string sql = "select * from Spell";
            SqlCommand comm = new SqlCommand(sql, scon);
            return comm;
        }
        private SqlCommand SpellInsert()
        {
            string sql = "insert into Spell values(@Spell_id, @Spell_name, @Spell_kor_name);";
            SqlCommand comm = new SqlCommand(sql, scon);
            comm.Parameters.Add("@Spell_id", SqlDbType.Int, sizeof(int), "Spell_id");
            comm.Parameters.Add("@Spell_name", SqlDbType.VarChar, 50, "Spell_name");
            comm.Parameters.Add("@Spell_kor_name", SqlDbType.VarChar, 50, "Spell_kor_name");
            return comm;
        }
        private SqlCommand SpellDelete()
        {
            string sql = "Delete from Spell where Spell_id = @Spell_id;";
            SqlCommand comm = new SqlCommand(sql, scon);

            comm.Parameters.Add("@Spell_id", SqlDbType.Int, 4, "Spell_id");

            return comm;
        }
        #endregion


        public void UpdateAll()
        {
            RuneAdapter.Update(RuneTable);
            SpellAdapter.Update(SpellTable);
        }

        public string GetRuneUrl(string rune_num)
        {
            int perk_id = int.Parse(rune_num);

            DataRow dr = RuneTable.Rows.Find(perk_id);

            return dr["perk_icon"].ToString();
        }

        public string GetSpellName(string spell_num)
        {
            int spell_id = int.Parse(spell_num);

            DataRow dr = SpellTable.Rows.Find(spell_id);

            return dr["spell_name"].ToString();
        }

    }
}
