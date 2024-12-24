using GTA;
using GTA.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using GTA.Math;
using GTA.Native;
using System.Drawing;

namespace WarrantV
{
    public static class EachTick
    {
        public static List<Tuple<string[], int[]>> VehList = new List<Tuple<string[], int[]>>();

        public static (int[], int)[] RecognizedClothes = { (new int[30], new int()), (new int[30], new int()), (new int[30], new int()) };
        public static bool[] Recognized = new bool[2];
        public static int[] WarrantLevel = new int[3];
        public static int WarrantLevelVeh;
        public static bool AnyCopRecog;
        public static int[] StarsEvaded = new int[3];
        public static Vector3 LastCopsPosition;
        public static Blip LastCopsPositionBlip;
<<<<<<< HEAD
        public static int LastCopsPositionBlipTimer = 0, CopsLostTimer = 0;
=======
        public static int LastCopsPositionBlipTimer=0, CopsLostTimer=0;
>>>>>>> 851ec09bf4e1c68b8946429376b8fd9d4fdf8580
        public static void Ped(Ped cop)
        {
            if (!Helpers.CopsList.Any(c => c.Item1 == cop))
            {
                Helpers.CopsList.Add(new Tuple<Ped, Blip, float[], int[], Vector3>(cop, cop.AddBlip(), new float[2], new int[3], new Vector3()));
            }
            int Index = Helpers.CopsList.FindIndex(c => c.Item1 == cop);
            Blip CopBlip = Helpers.CopsList[Index].Item2;
            float[] Recognition = new float[] { Helpers.CopsList[Index].Item3[0], Helpers.CopsList[Index].Item3[1] };
            int LastSeen = Helpers.CopsList[Index].Item4[0];
            int CallDelay = Helpers.CopsList[Index].Item4[1];
            int TaskType = Helpers.CopsList[Index].Item4[2];
            Vector3 LastSeenPos = Helpers.CopsList[Index].Item5;
            int NewTaskType = 0;
            if (Recognition[0] > 10 || Recognition[1] > 10) AnyCopRecog = true;
            if (!cop.IsAlive) { Recognition[0] = 0; Recognition[1] = 0; goto SavePed; }
            NewTaskType = Helpers.BlipHandle(cop, CopBlip, new float[] { Recognition[0], Recognition[1] }, TaskType, LastSeenPos, Helpers.Visible(Game.Player.Character, cop, Config.Numeric.CopsFOV, Config.Numeric.CopsVisibleDistance, Config.Numeric.CopsFOVinVeh));
            {
<<<<<<< HEAD
                if ((Helpers.CopsList.Count > 15 && (Main.Even && Index % 2 == 0) || (!Main.Even && Index % 2 == 1)) || Helpers.CopsList.Count <= 15)
=======
                if ((Helpers.CopsList.Count>15&&(Main.Even && Index % 2 == 0) || (!Main.Even && Index % 2 == 1))||Helpers.CopsList.Count<=15)
>>>>>>> 851ec09bf4e1c68b8946429376b8fd9d4fdf8580
                {
                    if (Helpers.Visible(Game.Player.Character, cop, Config.Numeric.CopsFOV, Config.Numeric.CopsVisibleDistance, Config.Numeric.CopsFOVinVeh))
                    {
                        LastSeen = Game.GameTime + Config.Numeric.TimeToLoseInterest;
                        LastSeenPos = Game.Player.Character.Position;
                        NewTaskType = 0;
<<<<<<< HEAD
                        if (Helpers.CompareArrays(RecognizedClothes[Helpers.PlayerID()].Item1, Helpers.GetPlayerClothes(), Config.Numeric.ClothesDifferencesToClearWarrant, true).Item1 && ((Recognition[0] > Config.Numeric.RememberNewClothesWhenAlmostRecognizedNumber && !Helpers.Masked().Item1) || (Game.Player.WantedLevel > 0 && Recognized[0]))) RecognizedClothes[Helpers.PlayerID()] = (Helpers.GetPlayerClothes(), RecognizedClothes[Helpers.PlayerID()].Item2); //when recognized > x remember new clothes
                        if (WarrantLevel[Helpers.PlayerID()] > 0 || WarrantLevelVeh > 0 || Game.Player.WantedLevel > 0 || Helpers.Masked().Item1)
                        {
                            if (!Recognized[0] && (WarrantLevel[Helpers.PlayerID()] > 0 || Game.Player.WantedLevel > 0 || Helpers.Masked().Item1)) if (Helpers.CopsList.Count > 15) Recognition[0] += Helpers.RecognitionAdd(cop) * 2; else Recognition[0] += Helpers.RecognitionAdd(cop);
                            if (!Recognized[1] && (WarrantLevelVeh > 0 || Game.Player.WantedLevel > 0)) if (Helpers.CopsList.Count > 15) Recognition[1] += Helpers.RecognitionAddCar(cop) * 2; else Recognition[1] += Helpers.RecognitionAddCar(cop);
=======
                        if (Helpers.CompareArrays(RecognizedClothes[Helpers.PlayerID()].Item1, Helpers.GetPlayerClothes(), Config.Numeric.ClothesDifferencesToClearWarrant, true).Item1 && ((Recognition[0] > 70 && !Helpers.Masked().Item1) || (Game.Player.WantedLevel > 0 && Recognized[0]))) RecognizedClothes[Helpers.PlayerID()] = (Helpers.GetPlayerClothes(), RecognizedClothes[Helpers.PlayerID()].Item2);
                        if (WarrantLevel[Helpers.PlayerID()] > 0 || WarrantLevelVeh > 0 || Game.Player.WantedLevel > 0 || Helpers.Masked().Item1)
                        {
                            if (!Recognized[0] && (WarrantLevel[Helpers.PlayerID()] > 0 || Game.Player.WantedLevel > 0 || Helpers.Masked().Item1)) if (Helpers.CopsList.Count > 15) Recognition[0] += Helpers.RecognitionAdd(cop) * 2; else Recognition[0] += Helpers.RecognitionAdd(cop);
                            if (!Recognized[1] && (WarrantLevelVeh > 0 || Game.Player.WantedLevel > 0)) if(Helpers.CopsList.Count > 15) Recognition[1] += Helpers.RecognitionAddCar(cop) * 2; else Recognition[1] += Helpers.RecognitionAddCar(cop);
>>>>>>> 851ec09bf4e1c68b8946429376b8fd9d4fdf8580
                        }
                    }
                }
                else
                if (LastSeen <= Game.GameTime)
                {
                    if (Recognition[0] > 0 && Recognition[0] < 100) Recognition[0] -= Config.Numeric.FaceForgetPerTick;
                    if (Recognition[1] > 0 && Recognition[1] < 100) Recognition[1] -= Config.Numeric.PlateForgetPerTick;
                    LastSeen = Game.GameTime + Config.Numeric.TimeToForgetFace;
                }
                if (Recognition[0] > 100)
                {
                    Recognition[0] = 100;
                }
                if (Recognition[1] > 100)
                {
                    Recognition[1] = 100;
                }
                if (Recognition[0] < 0)
                {
                    Recognition[0] = 0;
                }
                if (Recognition[1] < 0)
                {
                    Recognition[1] = 0;
                }

<<<<<<< HEAD
                if (Recognized[0] || (Helpers.Masked().Item1 && (Game.Player.WantedLevel > 0 || Function.Call<int>(Hash.GET_FAKE_WANTED_LEVEL) > 0))) Recognition[0] = 0;
=======
                if (Recognized[0] || (Helpers.Masked().Item1 && (Game.Player.WantedLevel > 0||Function.Call<int>(Hash.GET_FAKE_WANTED_LEVEL)>0))) Recognition[0] = 0;
>>>>>>> 851ec09bf4e1c68b8946429376b8fd9d4fdf8580
                if (Recognized[1]) Recognition[1] = 0;
                if (!Game.Player.Character.IsInVehicle()) Recognition[1] = 0;
                if (Recognition[0] == 100 || Recognition[1] == 100)
                {
<<<<<<< HEAD
                    if (Config.Bools.WantedWhenMasked) if (Helpers.Masked().Item1 && Game.Player.WantedLevel == 0)
=======
                    if(Config.Bools.WantedWhenMasked)if (Helpers.Masked().Item1 && Game.Player.WantedLevel == 0) 
>>>>>>> 851ec09bf4e1c68b8946429376b8fd9d4fdf8580
                        {
                            Game.Player.WantedLevel = 1;
                            Recognition[0] = 0;
                            if (Config.Bools.RecognitionScreenFX)
                            {
                                Screen.StartEffect((ScreenEffect)Config.Numeric.ScreenEffectID, 500, false);
                                Function.Call(Hash.FLASH_MINIMAP_DISPLAY);
                            }
                        }
                    if (CallDelay == 0 || (cop.IsRagdoll || cop.IsGettingUp || cop.IsGettingIntoVehicle || cop.IsClimbing || cop.IsBeingStealthKilled || cop.IsBeingStunned || cop.IsBeingStealthKilled)) CallDelay = Game.GameTime + Config.Numeric.BaseTimeToCall + (1000 * new Random().Next(Config.Numeric.AddedRandomTimeToCallMin, Config.Numeric.AddedRandomTimeToCallMax));
                    if (CallDelay > 0 && CallDelay - Config.Numeric.CallTime <= Game.GameTime)
                    {
                        if (cop.IsInVehicle())
                        {
                            if (Config.Bools.OnlyPassangerCanCall)
                            {
                                if (cop.CurrentVehicle.GetPedOnSeat(VehicleSeat.Driver) != cop || cop.CurrentVehicle.IsSeatFree(VehicleSeat.Passenger))
                                {
                                    if (Config.Bools.CopCallAnim)
                                    {
                                        cop.Task.UseMobilePhone(Config.Numeric.CallTime);
                                        cop.CurrentVehicle.LockStatus = VehicleLockStatus.Locked;
                                    }
                                    CallDelay = -CallDelay;
                                }
                            }
                            else
                            {
                                if (Config.Bools.CopCallAnim)
                                {
                                    cop.Task.UseMobilePhone(Config.Numeric.CallTime);
                                    cop.CurrentVehicle.LockStatus = VehicleLockStatus.Locked;
                                }
                                CallDelay = -CallDelay;

                            }

                        }
<<<<<<< HEAD
                        else if (cop.Position.DistanceTo(Game.Player.Character.Position) >= Config.Numeric.MinDistToCall || Game.Player.WantedLevel == 0)
=======
                        else if (cop.Position.DistanceTo(Game.Player.Character.Position) >= Config.Numeric.MinDistToCall || Game.Player.WantedLevel==0)
>>>>>>> 851ec09bf4e1c68b8946429376b8fd9d4fdf8580
                        {
                            if (Config.Bools.CopCallAnim)
                            {
                                cop.Task.UseMobilePhone(Config.Numeric.CallTime + 1000);
                                cop.Task.Cower(Config.Numeric.CallTime - 1000);
                            }
                            CallDelay = -CallDelay;
                        }
                        else
                        {
                            CallDelay = 0;
                        }
                    }

                    if (CallDelay < 0 && Math.Abs(CallDelay) <= Game.GameTime)
                    {
                        CallDelay = 0;
                        if (cop.IsInVehicle()) cop.CurrentVehicle.LockStatus = VehicleLockStatus.Unlocked;
                        if (Config.Bools.RecognitionScreenFX)
                        {
                            Screen.StartEffect((ScreenEffect)Config.Numeric.ScreenEffectID, 500, false);
                            Function.Call(Hash.FLASH_MINIMAP_DISPLAY);
                        }
                        if (Recognition[0] == 100 && !Helpers.Masked().Item1)
                        {
<<<<<<< HEAD
                            if (WarrantLevel[0] == 0)
=======
                            if(WarrantLevel[0]==0)
>>>>>>> 851ec09bf4e1c68b8946429376b8fd9d4fdf8580
                                RecognizedClothes[Helpers.PlayerID()] = (Helpers.GetPlayerClothes(), Game.Player.WantedLevel);
                            else
                                RecognizedClothes[Helpers.PlayerID()] = (Helpers.GetPlayerClothes(), WarrantLevel[0]);

                            Recognized[0] = true;
                            Recognition[0] = 0;
                            StarsEvaded[Helpers.PlayerID()] = Helpers.GetStat("STARS_EVADED", true);
                        }
                        if (Recognition[1] == 100)
                        {
                            Recognized[1] = true;
                            Recognition[1] = 0;
                            string[] ID = new string[]
                            {
                                Game.Player.Character.CurrentVehicle.Model.ToString(),
                                Game.Player.Character.CurrentVehicle.Mods.LicensePlate,
                                Game.Player.Character.CurrentVehicle.Mods.PrimaryColor.ToString()
                            };
                            if (!VehList.Any(c => c.Item1.SequenceEqual(ID))) VehList.Add(new Tuple<string[], int[]>(ID, new int[] { 0, Helpers.GetStat("STARS_EVADED", true) }));
                        }
                    }
                }
                if (Recognition[0] != 100 && Recognition[1] != 100) CallDelay = 0;
            }
        SavePed:
            if (Helpers.Masked().Item1 && !Config.Bools.WantedWhenMasked) Recognition[0] = 0;

            Helpers.CopsList[Index] = new Tuple<Ped, Blip, float[], int[], Vector3>(cop, CopBlip, new float[] { Recognition[0], Recognition[1] }, new int[] { LastSeen, CallDelay, NewTaskType }, LastSeenPos);
        }

        public static void MaskNerf(object sender, EventArgs e)
        {
            if (Config.Bools.MaskNerf)
            {
                if (Helpers.Masked().Item2)
                {
                    Function.Call(Hash.SET_PED_MOVE_RATE_OVERRIDE, Game.Player.Character, Config.Numeric.NerfSpeed);
                    Function.Call(Hash.SET_PLAYER_HEALTH_RECHARGE_MULTIPLIER, Game.Player, Config.Numeric.NerfRegen);

                }
                else
                {
                    Function.Call(Hash.SET_PED_MOVE_RATE_OVERRIDE, Game.Player.Character, Config.Numeric.NoNerfSpeed);
                    Function.Call(Hash.SET_PLAYER_HEALTH_RECHARGE_MULTIPLIER, Game.Player, Config.Numeric.NoNerfRegen);
                }
            }
        }

        public static void IVChases(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (Config.Bools.IVChases)
            {
                if (Game.Player.WantedLevel > 0)
                {
                    if (LastCopsPositionBlipTimer < Game.GameTime)
                    {
                        LastCopsPositionBlipTimer = Game.GameTime + 500;
                        if (LastCopsPositionBlip != null && LastCopsPositionBlip.Exists())
                        {
                            if (LastCopsPositionBlip.Color == BlipColor.Red) LastCopsPositionBlip.Color = BlipColor.Blue; else LastCopsPositionBlip.Color = BlipColor.Red;
                        }
                    }
                    if (!Function.Call<bool>(Hash.ARE_PLAYER_STARS_GREYED_OUT, Game.Player))
                    {
                        LastCopsPosition = Game.Player.Character.Position;
                        CopsLostTimer = 0;
                        if (LastCopsPositionBlip != null && LastCopsPositionBlip.Exists()) LastCopsPositionBlip.Delete();
                    }
                    else
=======
            if(Config.Bools.IVChases)
            {
                if(Game.Player.WantedLevel>0)
                {
                    if(LastCopsPositionBlipTimer<Game.GameTime)
                    {
                        LastCopsPositionBlipTimer = Game.GameTime+500;
                        if (LastCopsPositionBlip != null && LastCopsPositionBlip.Exists())
                        {
                            if(LastCopsPositionBlip.Color==BlipColor.Red) LastCopsPositionBlip.Color = BlipColor.Blue; else LastCopsPositionBlip.Color = BlipColor.Red;
                        }
                    }
                    if (!Function.Call<bool>(Hash.ARE_PLAYER_STARS_GREYED_OUT,Game.Player))
                    {
                        LastCopsPosition = Game.Player.Character.Position;
                        CopsLostTimer = 0;
                        if(LastCopsPositionBlip != null && LastCopsPositionBlip.Exists())LastCopsPositionBlip.Delete();
                    } else
>>>>>>> 851ec09bf4e1c68b8946429376b8fd9d4fdf8580
                    {
                        if (!(LastCopsPositionBlip != null && LastCopsPositionBlip.Exists()))
                        {
                            LastCopsPositionBlip = World.CreateBlip(LastCopsPosition, Game.Player.WantedLevel * 100 + 50);
                            LastCopsPositionBlip.Color = BlipColor.Red;
                            LastCopsPositionBlip.Alpha = 50;
                        }
                        if (Game.Player.Character.Position.DistanceTo(LastCopsPosition) > Game.Player.WantedLevel * 100 + 51)
                        {
                            if (CopsLostTimer == 0) CopsLostTimer = Game.GameTime + 8000 * (Game.Player.WantedLevel * 2);
                            if (CopsLostTimer < Game.GameTime) Game.Player.WantedLevel = 0;
                        }
                        else
                        {
                            CopsLostTimer = 0;
                        }
                    }
<<<<<<< HEAD
                }
                else
                {
                    CopsLostTimer = 0;
                    if (LastCopsPositionBlip != null && LastCopsPositionBlip.Exists()) LastCopsPositionBlip.Delete();
                }
            }
=======
                } else
                {
                        CopsLostTimer = 0;
                        if (LastCopsPositionBlip != null && LastCopsPositionBlip.Exists()) LastCopsPositionBlip.Delete();
                }
            }    
>>>>>>> 851ec09bf4e1c68b8946429376b8fd9d4fdf8580
        }

        public static class ChoiceMenus
        {
            public static bool buying, PlateChangeAble;
            public static Blip ClosestPhoneBoothBlip;
            public static Prop ClosestPhone;
            public static bool bribing;
            public static int HelpMessagePhoneDelay, HelpMessageSellerDelay;
            public static Vehicle ClosestVeh;

            public static void Phones(object sender, EventArgs e)
            {
                ClosestPhone = World.GetClosestProp(Game.Player.Character.Position, Config.Numeric.PhoneBlipDisplayDist, Helpers.PhoneModelsList);
                if (ClosestPhone != null)
                {
                    if (Config.Bools.PhoneBlipsEnabled)
                    {
                        if (ClosestPhone.AttachedBlip == null)
                        {
                            if (ClosestPhoneBoothBlip != null) ClosestPhoneBoothBlip.Delete();
                            ClosestPhoneBoothBlip = ClosestPhone.AddBlip();
                            ClosestPhoneBoothBlip.Sprite = (BlipSprite)Config.Numeric.PhoneBlipSrpite;
                            ClosestPhoneBoothBlip.Color = (BlipColor)Config.Numeric.PhoneBlipColor;
                            ClosestPhoneBoothBlip.IsShortRange = true;
                            ClosestPhoneBoothBlip.Scale = Config.Numeric.PhoneBlipScale;
                            ClosestPhoneBoothBlip.Name = Config.Strings.PhoneBlipName;//"Phone"
                        }
                    }
                    if (HelpMessagePhoneDelay > 0 && Game.GameTime < HelpMessagePhoneDelay)
                    {
                        Screen.ShowHelpTextThisFrame(Config.Strings.PhoneNoMoney);//$"You dont have enough money."
                    }

                    if (bribing)
                    {
                        Game.Player.CanControlCharacter = false;
                        string bribeText = Config.Strings.PhoneLeave;//$"Press ~INPUT_PICKUP~ to leave the telephone"
                        string playerNow = "";
                        switch (Helpers.PlayerID())
                        {
                            case 0:
                                playerNow = Config.Strings.PhoneButtonMichael;
                                break;
                            case 1:
                                playerNow = Config.Strings.PhoneButtonFranklin;
                                break;
                            case 2:
                                playerNow = Config.Strings.PhoneButtonTrevor;
                                break;
                        }
                        if (RecognizedClothes[Helpers.PlayerID()].Item2 > 0) bribeText += $"\n~{playerNow}~ {Config.Strings.PhoneToBribeCops} ({300 * Math.Pow(RecognizedClothes[Helpers.PlayerID()].Item2, 2) + 100}$)";//"To bribe cops"
                        if (RecognizedClothes[0].Item2 > 0 && Helpers.PlayerID() != 0) bribeText += $"\n~{Config.Strings.PhoneButtonMichael}~ {Config.Strings.PhoneToBribeCopsMichael} ({300 * Math.Pow(RecognizedClothes[0].Item2, 2) + 100}$)";//to bribe cops for M
                        if (RecognizedClothes[1].Item2 > 0 && Helpers.PlayerID() != 1) bribeText += $"\n~{Config.Strings.PhoneButtonFranklin}~ {Config.Strings.PhoneToBribeCopsFranklin} ({300 * Math.Pow(RecognizedClothes[1].Item2, 2) + 100}$)";//to bribe cops for F
                        if (RecognizedClothes[2].Item2 > 0 && Helpers.PlayerID() != 2) bribeText += $"\n~{Config.Strings.PhoneButtonTrevor}~ {Config.Strings.PhoneToBribeCopsTrevor} ({300 * Math.Pow(RecognizedClothes[2].Item2, 2) + 100}$)";//to bribe cops for T
                        Screen.ShowHelpTextThisFrame(bribeText);
                    }
                    if (Main.debug) new TextElement($"phone dist: {Math.Round(Game.Player.Character.Position.DistanceTo(ClosestPhone.Position + ClosestPhone.ForwardVector * (-0.5f)), 2)}", new PointF(400, 100), 0.4f, Color.White).Draw();

                    if (Game.Player.Character.Position.DistanceTo(ClosestPhone.Position + ClosestPhone.ForwardVector * (-0.5f)) <= 1.2f && !Game.Player.Character.IsInVehicle() && !bribing)
                    {
                        if (!Helpers.ObjectBroken(ClosestPhone))
                        {
                            if (Game.IsKeyPressed(System.Windows.Forms.Keys.E) && Game.GameTime >= -(HelpMessagePhoneDelay)) bribing = true;
                            if ((HelpMessagePhoneDelay <= 0 && Game.GameTime >= -(HelpMessagePhoneDelay)) || (HelpMessagePhoneDelay > 0 && Game.GameTime >= HelpMessagePhoneDelay)) Screen.ShowHelpTextThisFrame(Config.Strings.PhoneUse);//"Press ~INPUT_PICKUP~ to use the telephone.
                        }
                        else if ((HelpMessagePhoneDelay <= 0 && Game.GameTime >= -(HelpMessagePhoneDelay)) || (HelpMessagePhoneDelay > 0 && Game.GameTime >= HelpMessagePhoneDelay)) Screen.ShowHelpTextThisFrame(Config.Strings.PhoneBroken);//"This phone is broken."

                    }

                }
            }

            public static void Plates(object sender, EventArgs e)
            {
<<<<<<< HEAD
                if (Config.Bools.PlateChanging)
                {
                    if (HelpMessageSellerDelay < 0 && Game.GameTime > -(HelpMessageSellerDelay)) HelpMessageSellerDelay = 0;
                    if (HelpMessageSellerDelay > 0 && Game.GameTime > HelpMessageSellerDelay) HelpMessageSellerDelay = 0;
                    ClosestVeh = World.GetClosestVehicle(Game.Player.Character.Position, 20f);
                    if (Game.Player.Character.LastVehicle != null && Game.Player.Character.LastVehicle.Exists() && Game.Player.Character.LastVehicle.Position.DistanceTo(Game.Player.Character.Position) <= 5f) ClosestVeh = Game.Player.Character.LastVehicle;
                    if (ClosestVeh != null && ClosestVeh.Exists() && ClosestVeh.IsAlive && ClosestVeh.IsSeatFree(VehicleSeat.Driver))
                    {
                        if (Main.debug)
                        {
                            new TextElement("x", Screen.WorldToScreen(ClosestVeh.RearPosition), 0.5f).Draw();
                            new TextElement($"{ClosestVeh.Mods.LicensePlateType.ToString()}", Screen.WorldToScreen(ClosestVeh.Position), 0.5f).Draw();
                            new TextElement("x", Screen.WorldToScreen(ClosestVeh.FrontPosition), 0.5f).Draw();
                        }
                        if (Game.Player.Character.IsAlive && Game.Player.Character.IsIdle && Game.Player.Character.IsUpright && (Function.Call<bool>(Hash.ARE_PLAYER_STARS_GREYED_OUT, Game.Player) || Game.Player.WantedLevel == 0))
                        {
                            if (((ClosestVeh.Mods.LicensePlateType == LicensePlateType.RearPlate || ClosestVeh.Mods.LicensePlateType == LicensePlateType.FrontAndRearPlates) && ClosestVeh.RearPosition.DistanceTo(Game.Player.Character.Position) <= 1f) || (ClosestVeh.Mods.LicensePlateType == LicensePlateType.FrontPlate && ClosestVeh.FrontPosition.DistanceTo(Game.Player.Character.Position) <= 1f))
                            {
                                if (Main.Plates[Helpers.PlayerID()] > 0)
                                {
                                    Screen.ShowHelpTextThisFrame(Config.Strings.PlateChange);//"Press ~INPUT_PICKUP~ to change license plate."
                                    PlateChangeAble = true;
                                }
                                else
                                {
                                    Screen.ShowHelpTextThisFrame(Config.Strings.PlateNoMore);//"You dont have any license plates."
                                    PlateChangeAble = false;
                                }
                            }
                            else PlateChangeAble = false;

                        }
                        else PlateChangeAble = false;
                    }
                    else PlateChangeAble = false;
                    foreach (Vector3 sellerPos in Helpers.PayAndSprayLocations)
                    {
                        World.DrawMarker(MarkerType.VerticalCylinder, sellerPos - new Vector3(0, 0, 1f), new Vector3(), new Vector3(), new Vector3(1, 1, 1), Color.Yellow);
                        if (HelpMessageSellerDelay == 0)
                        {
                            if (Game.Player.Character.Position.DistanceTo(sellerPos) <= 0.66f)
                            {
                                Screen.ShowHelpTextThisFrame($"{Config.Strings.PlateBuy} {Config.Numeric.PlatePrice}$\n{Config.Strings.PlateBuyInfo} {Main.Plates[Helpers.PlayerID()]}/{Config.Numeric.PlateMaxNum} {Config.Strings.PlateBuyInfo2}");
                                buying = true;
                            }
                            else buying = false;
                        }
                        else
                        {
                            if (HelpMessageSellerDelay < 0 && Game.GameTime < -(HelpMessageSellerDelay))
                            {
                                Screen.ShowHelpTextThisFrame(Config.Strings.PlateNoMoney);//$"You dont have enough money."
                            }
                            if (HelpMessageSellerDelay > 0 && Game.GameTime < HelpMessageSellerDelay)
                            {
                                Screen.ShowHelpTextThisFrame(Config.Strings.PlateMaxAmnt);//$"You already have max amount of plates."
                            }
=======
                if (HelpMessageSellerDelay < 0 && Game.GameTime > -(HelpMessageSellerDelay)) HelpMessageSellerDelay = 0;
                if (HelpMessageSellerDelay > 0 && Game.GameTime > HelpMessageSellerDelay) HelpMessageSellerDelay = 0;
                ClosestVeh = World.GetClosestVehicle(Game.Player.Character.Position, 20f);
                if (Game.Player.Character.LastVehicle != null && Game.Player.Character.LastVehicle.Exists() && Game.Player.Character.LastVehicle.Position.DistanceTo(Game.Player.Character.Position) <= 5f) ClosestVeh = Game.Player.Character.LastVehicle;
                if (ClosestVeh != null && ClosestVeh.Exists() && ClosestVeh.IsAlive && ClosestVeh.IsSeatFree(VehicleSeat.Driver))
                {
                    if (Main.debug)
                    {
                        new TextElement("x", Screen.WorldToScreen(ClosestVeh.RearPosition), 0.5f).Draw();
                        new TextElement($"{ClosestVeh.Mods.LicensePlateType.ToString()}", Screen.WorldToScreen(ClosestVeh.Position), 0.5f).Draw();
                        new TextElement("x", Screen.WorldToScreen(ClosestVeh.FrontPosition), 0.5f).Draw();
                    }
                    if (Game.Player.Character.IsAlive && Game.Player.Character.IsIdle && Game.Player.Character.IsUpright && (Function.Call<bool>(Hash.ARE_PLAYER_STARS_GREYED_OUT, Game.Player) || Game.Player.WantedLevel == 0))
                    {
                        if (((ClosestVeh.Mods.LicensePlateType == LicensePlateType.RearPlate || ClosestVeh.Mods.LicensePlateType == LicensePlateType.FrontAndRearPlates) && ClosestVeh.RearPosition.DistanceTo(Game.Player.Character.Position) <= 1f) || (ClosestVeh.Mods.LicensePlateType == LicensePlateType.FrontPlate && ClosestVeh.FrontPosition.DistanceTo(Game.Player.Character.Position) <= 1f))
                        {
                            if (Main.Plates[Helpers.PlayerID()] > 0)
                            {
                                Screen.ShowHelpTextThisFrame(Config.Strings.PlateChange);//"Press ~INPUT_PICKUP~ to change license plate."
                                PlateChangeAble = true;
                            }
                            else
                            {
                                Screen.ShowHelpTextThisFrame(Config.Strings.PlateNoMore);//"You dont have any license plates."
                                PlateChangeAble = false;
                            }
                        }
                        else PlateChangeAble = false;

                    }
                    else PlateChangeAble = false;
                }
                else PlateChangeAble = false;
                foreach (Vector3 sellerPos in Helpers.PayAndSprayLocations)
                {
                    World.DrawMarker(MarkerType.VerticalCylinder, sellerPos - new Vector3(0, 0, 1f), new Vector3(), new Vector3(), new Vector3(1, 1, 1), Color.Yellow);
                    if (HelpMessageSellerDelay == 0)
                    {
                        if (Game.Player.Character.Position.DistanceTo(sellerPos) <= 0.66f)
                        {
                            Screen.ShowHelpTextThisFrame($"{Config.Strings.PlateBuy} {Config.Numeric.PlatePrice}$\n{Config.Strings.PlateBuyInfo} {Main.Plates[Helpers.PlayerID()]}/{Config.Numeric.PlateMaxNum} {Config.Strings.PlateBuyInfo2}");
                            buying = true;
                        }
                        else buying = false;
                    }
                    else
                    {
                        if (HelpMessageSellerDelay < 0 && Game.GameTime < -(HelpMessageSellerDelay))
                        {
                            Screen.ShowHelpTextThisFrame(Config.Strings.PlateNoMoney);//$"You dont have enough money."
                        }
                        if (HelpMessageSellerDelay > 0 && Game.GameTime < HelpMessageSellerDelay)
                        {
                            Screen.ShowHelpTextThisFrame(Config.Strings.PlateMaxAmnt);//$"You already have max amount of plates."
>>>>>>> 851ec09bf4e1c68b8946429376b8fd9d4fdf8580
                        }
                    }
                }
            }
        }

        public static class Graphics
        {
            private static bool[] WasPosterShowed = new bool[2];
            private static float[] AnimState = new float[2] { Config.Numeric.PlayerPosterAnimStartLoc, Config.Numeric.CarPosterAnimStartLoc };
<<<<<<< HEAD
            private static (int, bool, int) BlinkWanted = (0, false, 255);
=======
            private static (int,bool,int) BlinkWanted= (0,false,255);
>>>>>>> 851ec09bf4e1c68b8946429376b8fd9d4fdf8580

            public static void WarrantPosters(object sender, EventArgs e)
            {
                try
                {
                    if (!Function.Call<bool>(Hash.IS_PLAYER_SWITCH_IN_PROGRESS))
                    {
                        if (WarrantLevel[Helpers.PlayerID()] > 0 || Helpers.Masked().Item1)
                        {
                            if (!WasPosterShowed[0] || AnimState[0] != Config.Numeric.PlayerPosterAnimFinalLoc) { AnimState[0] -= 1f; }
                            if (AnimState[0] < Config.Numeric.PlayerPosterAnimFinalLoc) AnimState[0] = Config.Numeric.PlayerPosterAnimFinalLoc;
                            if (Helpers.Masked().Item1 && !Recognized[0])
                            {
                                //new GTA.UI.CustomSprite(".\\scripts\\Okoniewitz\\WarrantsV\\WantedMasked.png", new SizeF(70, 47), new PointF(AnimState[0] + 3, Config.Numeric.PlayerPosterHeight), Color.FromArgb(255, 255, 255, 255), 0).Draw();
                                if (Helpers.Masked().Item2) new GTA.UI.CustomSprite(".\\scripts\\Okoniewitz\\WarrantsV\\Masked.png", new SizeF(240 / 4, 69 / 4), new PointF(AnimState[0] + 40, Config.Numeric.PlayerPosterHeight + 25), Color.FromArgb(255, 255, 255, 255), 0, true).Draw();
                                else
                                {
                                    new GTA.UI.CustomSprite(".\\scripts\\Okoniewitz\\WarrantsV\\NearWanted.png", new SizeF(240 / 4, 69 / 4), new PointF(AnimState[0] + 40, Config.Numeric.PlayerPosterHeight + 25), Color.FromArgb(255, 255, 255, 255), 0, true).Draw();
                                }

                            }
                            else
                                new GTA.UI.CustomSprite(".\\scripts\\Okoniewitz\\WarrantsV\\Wanted" + Helpers.PlayerID() + ".png", new SizeF(70, 47), new PointF(AnimState[0] + 3, Config.Numeric.PlayerPosterHeight), Color.FromArgb(255, 255, 255, 255), 0).Draw();
                            if (!EachTick.Recognized[0] && !Helpers.Masked().Item1)
                            {
                                //Game.GameTime + 200* Helpers.CompareArrays(EachTick.RecognizedClothes[Helpers.PlayerID()].Item1, Helpers.GetPlayerClothes(), 2, true).Item2;
                                if (Game.GameTime > BlinkWanted.Item1)
                                {
                                    BlinkWanted.Item1 = Game.GameTime + 20;
                                    int minAlpha = 180 - (40 * Helpers.CompareArrays(EachTick.RecognizedClothes[Helpers.PlayerID()].Item1, Helpers.GetPlayerClothes(), 2, true).Item2);
                                    if (Helpers.CompareArrays(EachTick.RecognizedClothes[Helpers.PlayerID()].Item1, Helpers.GetPlayerClothes(), 2, true).Item2 <= 0) minAlpha = 255;
                                    if (BlinkWanted.Item2)
                                    {
                                        BlinkWanted.Item3 += 5;
<<<<<<< HEAD
                                    }
                                    else
=======
                                    } else
>>>>>>> 851ec09bf4e1c68b8946429376b8fd9d4fdf8580
                                    {
                                        BlinkWanted.Item3 -= 5;
                                    }
                                    if (BlinkWanted.Item3 >= 255)
                                        BlinkWanted.Item2 = false;
                                    if (BlinkWanted.Item3 <= minAlpha)
                                        BlinkWanted.Item2 = true;
                                    if (BlinkWanted.Item3 > 255) BlinkWanted.Item3 = 255; if (BlinkWanted.Item3 < 0) BlinkWanted.Item3 = 0;
                                }
                                new GTA.UI.CustomSprite(".\\scripts\\Okoniewitz\\WarrantsV\\Wanted.png", new SizeF(240 / 4, 69 / 4), new PointF(AnimState[0] + 35, Config.Numeric.PlayerPosterHeight + 3), Color.FromArgb(BlinkWanted.Item3, Color.White), 0, true).Draw();
                            }
                            WasPosterShowed[0] = true;
                        }
                        else
                        {
                            WasPosterShowed[0] = false;
                            AnimState[0] = Config.Numeric.PlayerPosterAnimStartLoc;
                        }
                        if (EachTick.WarrantLevelVeh > 0 && Game.Player.Character.IsInVehicle())
                        {
                            if (!WasPosterShowed[1] || AnimState[1] != Config.Numeric.CarPosterAnimFinalLoc) { AnimState[1] -= 1f; }
                            if (AnimState[1] < Config.Numeric.CarPosterAnimFinalLoc) AnimState[1] = Config.Numeric.CarPosterAnimFinalLoc;
                            new GTA.UI.Sprite("vehshare", Helpers.GetVehPlate(Game.Player.Character.CurrentVehicle), new SizeF(90, 45), new PointF(AnimState[1], Config.Numeric.CarPosterHeight)).Draw();

                            if (!EachTick.Recognized[1])
                            {
                                new GTA.UI.TextElement(Config.Strings.PlateWanted, new PointF(AnimState[1] + 45, Config.Numeric.CarPosterHeight + 10), 0.76f, Helpers.PlateTextColor, GTA.UI.Font.ChaletComprimeCologne, GTA.UI.Alignment.Center).Draw();
                            }
                            else
                            {
                                if (Game.Player.Character.CurrentVehicle.Mods.LicensePlateType != LicensePlateType.None || Config.Bools.AlwaysShowPlate)
                                {
                                    new GTA.UI.TextElement(Game.Player.Character.CurrentVehicle.Mods.LicensePlate, new PointF(AnimState[1] + 45, Config.Numeric.CarPosterHeight + 10), 0.76f, Helpers.PlateTextColor, GTA.UI.Font.ChaletComprimeCologne, GTA.UI.Alignment.Center).Draw();
                                }
                                else
                                    new GTA.UI.TextElement(Config.Strings.PlateRecognized, new PointF(AnimState[1] + 45, Config.Numeric.CarPosterHeight + 10), 0.76f, Helpers.PlateTextColor, GTA.UI.Font.ChaletComprimeCologne, GTA.UI.Alignment.Center).Draw();
                            }
                            WasPosterShowed[1] = true;
                        }
                        else
                        {
                            WasPosterShowed[1] = false;
                            AnimState[1] = Config.Numeric.CarPosterAnimStartLoc;
                        }

                    }
                }
                catch { };
            }
        }

    }
}