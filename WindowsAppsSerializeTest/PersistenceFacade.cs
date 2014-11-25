using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Newtonsoft.Json;

namespace WindowsAppsSerializeTest
{
    class PersistenceFacade
    {
        private static string jsonFileName = "PersonsAsJson.dat";
        private static string xmlFileName = "PersonsAsXml.dat";
 
        public static async void SavePersonsAsJsonAsync(ObservableCollection<Person> persons)
        {
            string personsJsonString = JsonConvert.SerializeObject(persons);
            SerializePersonsFileAsync(personsJsonString, jsonFileName);
        }

        public static async Task<List<Person>> LoadPersonsFromJsonAsync()
        {
            string personsJsonString = await DeSerializePersonsFileAsync(jsonFileName);
            return (List<Person>)JsonConvert.DeserializeObject(personsJsonString, typeof(List<Person>));  
        }

        public static async void SavePersonsAsXmlAsync(ObservableCollection<Person> persons)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(persons.GetType());
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, persons);          
            SerializePersonsFileAsync(textWriter.ToString(), xmlFileName);
        }

        public static async Task<ObservableCollection<Person>> LoadPersonsFromXmlAsync()
        {
            string personsXmlString = await DeSerializePersonsFileAsync(xmlFileName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Person>));
            return (ObservableCollection<Person>)xmlSerializer.Deserialize(new StringReader(personsXmlString));           
        }
  
      
        public static async void SerializePersonsFileAsync(string PersonsString, string fileName)
        {       
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, PersonsString);
        }

        public static async Task<string> DeSerializePersonsFileAsync(String fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return await FileIO.ReadTextAsync(localFile);           
        }



    }
}
