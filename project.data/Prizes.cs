using project.data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.data
{
    public class Prizes : DatabaseContext
    {
        
        public static IEnumerable<PrizeModel.Prizes_Load> Raffle_Prizes_Load()
        {
            try
            {
                var RecordSet = new DatabaseContext().DoFetch<PrizeModel.Prizes_Load>("spRaffle_Prizes_Load");
                return RecordSet;
            }
            catch (Exception err)
            {
                _ = err.Message;
                return Enumerable.Empty<PrizeModel.Prizes_Load>();
            }
        }
        public static IEnumerable<PrizeModel.Entries_LoadAll> Raffle_Entries_ReturnMyEntries_ByEmail(string email)
        {
            try
            {
                var prm = new List<SqlParameter>
                {
                    new SqlParameter("@email", email),
                };
                var spCall = DatabaseContextClass.PrepareSpCall("spRaffle_Entries_ReturnMyEntries_ByEmail", prm);
                var loginDetails = new DatabaseContext().DoFetch<PrizeModel.Entries_LoadAll>(spCall, prm);
                return loginDetails;
            }
            catch (Exception err)
            {
                _ = err.Message;
                return Enumerable.Empty<PrizeModel.Entries_LoadAll>();
            }
        }
  
        public static IEnumerable<PrizeModel.Entries_LoadAll> Raffle_Entries_LoadAll()
        {
            try
            {
                var RecordSet = new DatabaseContext().DoFetch<PrizeModel.Entries_LoadAll>("spRaffle_Entries_LoadAll");
                return RecordSet;
            }
            catch (Exception err)
            {
                _ = err.Message;
                return Enumerable.Empty<PrizeModel.Entries_LoadAll>();
            }
        }
        public static bool Raffle_Prizes_ChooseWinner(int PrizeID)
        {
            bool success = false;
            try
            {
                var prm = new List<SqlParameter>
                {
                    new SqlParameter("@id", PrizeID)
                };
                var spCall = DatabaseContextClass.PrepareSpCall("spRaffle_Prizes_ChooseWinner", prm);
                new DatabaseContext().DoExec(spCall, prm);
                success = true;
                return success;
            }
            catch (Exception err)
            {
                _ = err.Message;
                return false;
            }
        }
        public static bool Raffle_Prize_Add(string PrizeName, string PrizeDescription = "")
        {
            bool success = false;
            try
            {
                var prm = new List<SqlParameter>
                {
                    new SqlParameter("@PrizeName", PrizeName),
                    new SqlParameter("@PrizeDescription", PrizeDescription)

                };
                var spCall = DatabaseContextClass.PrepareSpCall("spRaffle_Prize_Add", prm);
                new DatabaseContext().DoExec(spCall, prm);
                success = true;
                return success;
            }
            catch (Exception err)
            {
                _ = err.Message;
                return false;
            }
        }
        public static bool Raffle_Entries_Add(string Email, int NumberofEntries)
        {
            bool success = false;
            try
            {
                var prm = new List<SqlParameter>
                {
                    new SqlParameter("@Email", Email),
                    new SqlParameter("@NumberofEntries", NumberofEntries)

                };
                var spCall = DatabaseContextClass.PrepareSpCall("spRaffle_Entries_Add", prm);
                new DatabaseContext().DoExec(spCall, prm);
                success = true;
                return success;
            }
            catch (Exception err)
            {
                _ = err.Message;
                return false;
            }
        }
        public static bool Raffle_Entries_Delete(int EntryID)
        {
            bool success = false;
            try
            {
                var prm = new List<SqlParameter>
                {
                    new SqlParameter("@EntryID", EntryID)
                };
                var spCall = DatabaseContextClass.PrepareSpCall("spRaffle_Entries_Delete", prm);
                new DatabaseContext().DoExec(spCall, prm);
                success = true;
                return success;
            }
            catch (Exception err)
            {
                _ = err.Message;
                return false;
            }
        }
        public static bool Raffle_Prize_Delete(int PrizeID)
        {
            bool success = false;
            try
            {
                var prm = new List<SqlParameter>
                {
                    new SqlParameter("@PrizeID", PrizeID)
                };
                var spCall = DatabaseContextClass.PrepareSpCall("spRaffle_Prize_Delete", prm);
                new DatabaseContext().DoExec(spCall, prm);
                success = true;
                return success;
            }
            catch (Exception err)
            {
                _ = err.Message;
                return false;
            }
        }
    }
}
