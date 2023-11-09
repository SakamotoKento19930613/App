using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manage753.src.Helpers
{
    internal class AddressHelper
    {
        private Dictionary<string, AddressData> postalCodeData; // 郵便番号と都道府県、市区町村の対応データ

        public AddressHelper()
        {
            LoadDataFromCsv();
        }

        public void LoadDataFromCsv()
        {
            postalCodeData = new Dictionary<string, AddressData>();
            string csvFilePath = ConfigurationManager.AppSettings["AddressFilePath"];
            if (File.Exists(csvFilePath))
            {
                using (StreamReader reader = new StreamReader(csvFilePath, Encoding.GetEncoding("Shift-JIS")))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] columns = line.Split(',');
                        string postalCode = columns[2].Trim('\"');
                        string prefecture = columns[6].Trim('\"');
                        string city = columns[7].Trim('\"');
                        city = city + columns[8].Trim('\"');
                        postalCodeData[postalCode] = new AddressData
                        {
                            Prefecture = prefecture,
                            City = city
                        };
                    }
                }
            }
            else
            {
                MessageBox.Show("CSVファイルが見つかりません。", "SYSTEMERROR");
            }
        }
        public bool PostalCodeExists(string postalCode)
        {
            return postalCodeData.ContainsKey(postalCode);
        }

        public AddressData GetAddressData(string postalCode)
        {
            if (postalCodeData.TryGetValue(postalCode, out var addressData))
            {
                return addressData;
            }
            return null;
        }
    }
}
