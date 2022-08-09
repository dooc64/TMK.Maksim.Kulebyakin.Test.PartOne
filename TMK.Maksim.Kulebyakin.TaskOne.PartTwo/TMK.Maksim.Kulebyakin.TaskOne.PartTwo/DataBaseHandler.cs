using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace TMK.Maksim.Kulebyakin.TaskOne.PartTwo
{
    public class DataBaseHandler
    {
        private readonly string _connectionString = "Data Source=mk;Initial Catalog=TMK.Maksim.Kulebyakin.Test.Base;Integrated Security=True";

        public async Task<List<DisplayedFirm>> GetFilteredFirms(string firmName, string jurCityName, string postCityName)
        {
            return await Task.Run(() =>
            {
                List<DisplayedFirm> displayedFirms = new List<DisplayedFirm>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();

                    command.CommandText = "dbo.SearchByFirmNameAndCityName";
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@FirmName", string.IsNullOrWhiteSpace(firmName) ? DBNull.Value : firmName);
                    command.Parameters.AddWithValue("@JurCityName", string.IsNullOrWhiteSpace(jurCityName) ? DBNull.Value : jurCityName);
                    command.Parameters.AddWithValue("@PostCityName", string.IsNullOrWhiteSpace(postCityName) ? DBNull.Value : postCityName);

                    connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var firm = new DisplayedFirm()
                        {
                            CityId = int.Parse(reader["JUR_CITY_ID"].ToString()),
                            FirmName = reader["NAME"] as string,
                            JurCityName = reader["CityName"] as string,
                            FirmId = int.Parse(reader["FIRM_ID"].ToString())
                        };
                        displayedFirms.Add(firm);
                    }
                }

               Debug.WriteLine(displayedFirms.Count);

                return displayedFirms;
            });
        }

        public List<DisplayedFirm> GetFilteredFirms1(string firmName, string jurCityName, string postCityName)
        {

            List<DisplayedFirm> displayedFirms = new List<DisplayedFirm>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandText = "dbo.SearchByFirmNameAndCityName";
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.AddWithValue("@FirmName", string.IsNullOrWhiteSpace(firmName) ? DBNull.Value : firmName);
                command.Parameters.AddWithValue("@JurCityName", string.IsNullOrWhiteSpace(jurCityName) ? DBNull.Value : jurCityName);
                command.Parameters.AddWithValue("@PostCityName", string.IsNullOrWhiteSpace(postCityName) ? DBNull.Value : postCityName);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var firm = new DisplayedFirm()
                    {
                        CityId = int.Parse(reader["JUR_CITY_ID"].ToString()),
                        FirmName = reader["NAME"] as string,
                        JurCityName = reader["CityName"] as string,
                        FirmId = int.Parse(reader["FIRM_ID"].ToString())
                    };
                    displayedFirms.Add(firm);
                }
            }

            Debug.WriteLine(displayedFirms.Count);

            return displayedFirms;
        }
    }
}
