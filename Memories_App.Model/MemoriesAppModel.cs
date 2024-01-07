﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memories_App.Persistence;
using Memories_App.Persistence.DTO;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using Image = SixLabors.ImageSharp.Image;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Bmp;
using System.Collections.Specialized;

namespace Memories_App.Model
{
    public class MemoriesAppModel : IDisposable
    {

        private bool _isDisposed;

        IMemoriesAppPersistence _persistence;

        public ObservableCollection<UserMemory> Memories { get; set; }

        public Image<Rgba32>? NewImage { get; set; }



        public event EventHandler? HomePageLoaded;
        public event EventHandler? SearchPageLoaded;
        public event EventHandler? DetailsPageLoaded;
        public event EventHandler? StatisticsPageLoaded;
        public event EventHandler? NewPicturePageLoaded;
        public event EventHandler? PhotoLoaded;

        public MemoriesAppModel(IMemoriesAppPersistence persistence)
        {
            _persistence = persistence;
            Memories = new();
            /*
            var memories = _persistence.GetAllUserMemoriesAsync().Result;
            foreach (var memory in memories)
            {
                Memories.Add(memory);
            }
            */
        }


        private void OnHomePageLoaded() => HomePageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnSearchPageLoaded() => SearchPageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnDetailsPageLoaded() => DetailsPageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnStatisticsPageLoaded() => StatisticsPageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnNewPicturePageLoaded() => NewPicturePageLoaded?.Invoke(this, EventArgs.Empty);
        private void OnPhotoLoaded() => PhotoLoaded?.Invoke(this, EventArgs.Empty);



        public async Task LoadImage(Stream imageStream)
        {
            if (NewImage is not null)
            {
                NewImage.Dispose();
                NewImage = null;
            }
            NewImage = await Image.LoadAsync<Rgba32>(imageStream);
            NewImage.Mutate(x => x.Resize(256, 256));

            OnPhotoLoaded();
        }


        public async Task<IEnumerable<int>> FilterMemoriesAsync(string filterBy, string filterValue)
        {/*
            switch (filterBy)
            {
                case "Title":
                    return Memories.Select(x => x.Id).Where(id => Memories.Where(memory => memory.Title.Contains(filterValue)).Select(x => x.Id).Contains(id));
                case "Description":
                    Memories.Where(memory => memory.Description.Contains(filterValue));
                case "Tags":
                    Memories.Where(memory => memory.Tags.Contains(filterValue));
                case "Date":
                    DateTime filterDate = DateTime.Parse(filterValue);
                    Memories.Where(memory => memory.Date >= filterDate && memory.Date <= DateTime.Today);
                default:
            }
                    return new List<UserMemory>();
            */
            return new List<int>();
        }

        public async Task LoadHomePageAsync()
        {
            /*
            Memories.Clear();
            foreach (var memory in await _persistence.GetAllUserMemoriesAsync())
            {
                Memories.Add(memory);
            }
            */
            OnHomePageLoaded();
        }

        public async Task SaveMemoriesAsync()
        {
            await _persistence.SaveAllUserMemoriesAsync(Memories);
        }


        public async Task LoadSearchPageAsync()
        {
            OnSearchPageLoaded();
        }

        public async Task LoadDetailsPageAsync()
        {
            OnDetailsPageLoaded();
        }

        public async Task LoadStatisticsPageAsync()
        {
            OnStatisticsPageLoaded();
        }

        public async Task LoadNewPicturePageAsync()
        {
            OnNewPicturePageLoaded();
        }


        #region Additional Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (NewImage is not null)
                    {
                        NewImage.Dispose();
                        NewImage = null;
                        Memories.Clear();
                    }
                }
                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public Stream? GetImageStream()
        {
            if (NewImage != null)
            {
                MemoryStream ms = new MemoryStream();              
                var encoder = new BmpEncoder();
                NewImage.Save(ms, encoder);
                ms.Seek(0, SeekOrigin.Begin);
                return ms;
                
            }
            else return null;
        }



        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;

        public async Task<Location> GetCurrentLocation()
        {
            Location location = null;

            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                
            }
            // Catch one of the following exceptions:
            //   FeatureNotSupportedException
            //   FeatureNotEnabledException
            //   PermissionException
            catch (Exception ex)
            {
                // Unable to get location
            }
            finally
            {
                _isCheckingLocation = false;
            }
            return location;
        }

        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
                _cancelTokenSource.Cancel();
        }

        #endregion
    }
}
