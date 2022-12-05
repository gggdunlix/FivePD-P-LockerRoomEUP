using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using FivePD.API;
using FivePD.API.Utils;
using CitizenFX.Core.Native;
using Newtonsoft.Json.Linq;
using MenuAPI;

namespace FivePDEUPLocker
{
    public class FivePDEUPLocker
    {
        public class Plugin : FivePD.API.Plugin
        {
            public bool muted;
            internal Plugin()
            {
                try
                {
                    var json = API.LoadResourceFile(API.GetCurrentResourceName(), "/config/coordinates.json");
                    var config = JObject.Parse(json);
                    var locations = config["LockerEUP"]["locations"];
                    var locConfig = locations[0];
                    var posJSON = locConfig["coords"];
                    Vector3 position = new Vector3((float)posJSON["x"], (float)posJSON["y"], (float)posJSON["z"]);
                    bool blipStatus = (bool)locConfig["blip"];
                    bool markerStatus = (bool)locConfig["marker"];
                    string tooltip = locConfig["tooltip"].ToString();
                    Debug.WriteLine("FivePD EUP Locker: JSON Files loaded, no errors found...");
                    foreach (JObject _locConfig in locations)
                    {
                        var _posJSON = _locConfig["coords"];
                        Vector3 _position = new Vector3((float)_posJSON["x"], (float)_posJSON["y"], (float)_posJSON["z"]);
                        bool _blipStatus = (bool)_locConfig["blip"];
                        bool _markerStatus = (bool)_locConfig["marker"];
                        string _tooltip = _locConfig["tooltip"].ToString();

                        if (blipStatus)
                        {
                            Blip cBlip = new Blip(API.AddBlipForCoord(position.X, position.Y, position.Z));
                            cBlip.Color = BlipColor.Blue;
                            cBlip.Sprite = BlipSprite.Clothes;
                        }
                    }
                        Tick += isNear;
                } catch (Exception ex)
                {
                    Debug.WriteLine("FivePD EUP Locker: Error in the coordinates.json: " + ex);
                    Tick -= isNear;

                }
            }

            public async Task isNear()
            {
                {
                    
                    var json = API.LoadResourceFile(API.GetCurrentResourceName(), "/config/coordinates.json");
                    var config = JObject.Parse(json);
                    var locations = config["LockerEUP"]["locations"];
                    foreach (JObject locConfig in locations)
                    {
                        var posJSON = locConfig["coords"];
                        Vector3 position = new Vector3((float)posJSON["x"], (float)posJSON["y"], (float)posJSON["z"]);
                        bool markerStatus = (bool)locConfig["marker"];
                        string tooltip = locConfig["tooltip"].ToString();

                        if (markerStatus)
                        {
                            if (Game.PlayerPed.IsInRangeOf(position, 25f))
                            {

                                API.DrawMarker(((int)MarkerType.VerticalCylinder), position.X, position.Y, position.Z, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1f, 1f, 1f, 100, 149, 237, 50, false, false, 2, false, (string)null, (string)null, false);
                                
                                
                            }
                        }
                        if (Game.PlayerPed.IsInRangeOf(position, 2f))
                        {
                            API.BeginTextCommandDisplayHelp("STRING");
                            API.AddTextComponentSubstringPlayerName(tooltip);
                            API.EndTextCommandDisplayHelp(0, false, true, -1);

                            if (API.IsControlJustPressed(0, 51))
                            {
                                API.ExecuteCommand("eup");
                            }
                        }

                    }


                }




            }
        }
    }
}
