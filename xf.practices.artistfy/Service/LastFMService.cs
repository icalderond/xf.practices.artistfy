using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using QuickType;
using xf.practices.artistfy.Persistence;

namespace xf.practices.artistfy.Service
{
    public class LastFMService
    {
        public event EventHandler<GenericEventArgs<MessageResult<IList<Track>>>> TrackSearch_Completed;

        /// <summary>
        /// Tracks the search.
        /// http://ws.audioscrobbler.com/2.0/?method=artist.search&artist={busqueda}&api_key={personal_api_key}&format=json
        /// </summary>
        /// <param name="search">Search.</param>
        public async void TrackSearch(string search)
        {
            var messageResult = new MessageResult<IList<Track>>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ConfigApi.MediaTypeJson));
                    var response = await client.GetAsync(ConfigApi.UrlLastFM + ConfigApi.TrackSearchEndPoint + $"&track={search}&api_key={ConfigApi.ApiKey_LastFM}&format=json");

                    if (response.IsSuccessStatusCode)
                    {
                        var ContentString = await response.Content.ReadAsStringAsync();

                        var trackResponse = Welcome.FromJson(ContentString);
                        messageResult.Result = new List<Track>(trackResponse.Results.Trackmatches.Track);
                        messageResult.IsSuccess = true;
                    }
                    else
                    {
                        throw new Exception("Hubo un error al consultar el track");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            TrackSearch_Completed?.Invoke(this, new GenericEventArgs<MessageResult<IList<Track>>>(messageResult));
        }
    }
}
