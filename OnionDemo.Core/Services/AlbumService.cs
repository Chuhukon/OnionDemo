using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Core.Base;
using OnionDemo.Core.Model;

namespace OnionDemo.Core.Services
{
    public class AlbumService
    {
        private IValidationDictionary _validationDictionary;
        private IAlbumRepository _repository;

        public AlbumService(IAlbumRepository repository, IValidationDictionary dictionary)
        {
            _repository = repository;
            _validationDictionary = dictionary;
        }

        private bool ValidateAlbum(Album album)
        {
            if (string.IsNullOrEmpty(album.Name))
            {
                _validationDictionary.AddError("Name", "Name field is not filled");
            }

            return _validationDictionary.IsValid;
        }

        public bool CreateAlbum(Album newAlbum)
        {
            // Validation logic 
            if (!ValidateAlbum(newAlbum))
                return false;

            try
            {
                _repository.InsertOrUpdate(newAlbum);
                _repository.Save();
            }
            catch
            {
                return false;
            }
            return true;
        } 


        
    }
}
