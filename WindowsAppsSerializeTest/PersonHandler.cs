using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAppsSerializeTest
{
    class PersonHandler
    {
        private PersonsViewModel personsViewModel;

        public PersonHandler(PersonsViewModel personsViewModel)
        {
            this.personsViewModel = personsViewModel;
        }

        public void AddPersons()
        {
            personsViewModel.AddPersons();
        }

        public async void SavePersonsAsync()
        {
            PersistenceFacade.SavePersonsAsJsonAsync(personsViewModel.Persons);
        }

        public async void LoadPersonsAsync()
        {
            var persons = await PersistenceFacade.LoadPersonsFromJsonAsync();
            personsViewModel.Persons.Clear();
            foreach (var person in persons)
            {
             personsViewModel.Persons.Add(person);   
            }
        }
    }
}
