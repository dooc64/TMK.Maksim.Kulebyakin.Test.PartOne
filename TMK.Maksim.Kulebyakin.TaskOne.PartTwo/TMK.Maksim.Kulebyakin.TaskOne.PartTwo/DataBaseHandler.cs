using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections.ObjectModel;

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

        public async Task<List<DisplayedDocument>> GetFilteredDocumentsByFirmId(int id)
        {
            return await Task.Run(() =>
            {
                List<DisplayedDocument> filteredDocuments = new List<DisplayedDocument>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetDocumentsByFirmId]";

                    command.Parameters.AddWithValue("FirmId", id);

                    connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var document = new DisplayedDocument()
                        {
                            Year = (int)reader[0],
                            January = (int)reader[1],
                            February = (int)reader[2],
                            March = (int)reader[3],
                            April = (int)reader[4],
                            May = (int)reader[5],
                            June = (int)reader[6],
                            July = (int)reader[7],
                            August = (int)reader[8],
                            September = (int)reader[9],
                            October = (int)reader[10],
                            November = (int)reader[11],
                            December = (int)reader[12]
                        };

                        filteredDocuments.Add(document);
                    }
                }
                return filteredDocuments;
            });
        }
    }
}
