﻿using MagicMirror.Business.Models.User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MagicMirror.UniversalApp.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public static async Task SetValuesAsync(UserViewModel model, UserProfileModel userProfile)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                model.Id = userProfile.Id;
                model.PersonId = userProfile.PersonId;
                model.FaceId = new ObservableCollection<Guid>(userProfile.FaceIds);
                model.FirstName = userProfile.FirstName;
                model.LastName = userProfile.LastName;
                model.Addresses = UserAddressViewModel.BuildAddresses(userProfile.Addresses);
            });
        }

        private Guid _id;
        private Guid _personId;
        private ObservableCollection<Guid> _faceIds;
        private ObservableCollection<UserAddressViewModel> _addresses;
        private string _firstName;
        private string _lastName;

        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }

        public Guid PersonId
        {
            get
            {
                return _personId;
            }
            set
            {
                _personId = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Guid> FaceId
        {
            get
            {
                return _faceIds;
            }
            set
            {
                _faceIds = value;
                NotifyPropertyChanged();
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<UserAddressViewModel> Addresses
        {
            get
            {
                return _addresses;
            }
            set
            {
                _addresses = value;
                NotifyPropertyChanged();
            }
        }
    }

    public class UserAddressViewModel : ViewModelBase
    {
        private Guid _id;
        private Guid _addressTypeId;
        private string _addressTypeName;
        private Guid _addressId;
        private string _addressStreet;
        private string _addressHouseNumber;
        private string _addressHouseNumberSuffix;
        private string _addressPostCode;
        private string _addressCity;

        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }

        public Guid AddressTypeId
        {
            get
            {
                return _addressTypeId;
            }
            set
            {
                _addressTypeId = value;
                NotifyPropertyChanged();
            }
        }

        public string AddressTypeName
        {
            get
            {
                return _addressTypeName;
            }
            set
            {
                _addressTypeName = value;
                NotifyPropertyChanged();
            }
        }

        public Guid AddressId
        {
            get
            {
                return _addressId;
            }
            set
            {
                _addressId = value;
                NotifyPropertyChanged();
            }
        }

        public string AddressStreet
        {
            get
            {
                return _addressStreet;
            }
            set
            {
                _addressStreet = value;
                NotifyPropertyChanged();
            }
        }

        public string AddressHouseNumber
        {
            get
            {
                return _addressHouseNumber;
            }
            set
            {
                _addressHouseNumber = value;
                NotifyPropertyChanged();
            }
        }

        public string AddressHouseNumberSuffix
        {
            get
            {
                return _addressHouseNumberSuffix;
            }
            set
            {
                _addressHouseNumberSuffix = value;
                NotifyPropertyChanged();
            }
        }

        public string AddressPostCode
        {
            get
            {
                return _addressPostCode;
            }
            set
            {
                _addressPostCode = value;
                NotifyPropertyChanged();
            }
        }

        public string AddressCity
        {
            get
            {
                return _addressCity;
            }
            set
            {
                _addressCity = value;
                NotifyPropertyChanged();
            }
        }

        internal static ObservableCollection<UserAddressViewModel> BuildAddresses(List<UserAddressModel> addresses)
        {
            var result = new ObservableCollection<UserAddressViewModel>();
            foreach (var a in addresses)
            {
                result.Add(new UserAddressViewModel
                {
                    Id = a.Id,
                    AddressTypeId = a.AddressTypeId,
                    AddressTypeName = a.AddressTypeName,
                    AddressId = a.AddressId,
                    AddressStreet = a.AddressStreet,
                    AddressHouseNumber = a.AddressHouseNumber,
                    AddressHouseNumberSuffix = a.AddressHouseNumberSuffix,
                    AddressPostCode = a.AddressPostCode,
                    AddressCity = a.AddressCity
                });
            }
            return result;
        }
    }
}