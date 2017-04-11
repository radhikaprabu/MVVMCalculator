﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public static class Toolkit
    {
        public static void Init()
        {
        }
    }
    public class AdderViewModel : ViewModelBase
    {
        string currentEntry = "0";
        string historyString = "";
        bool isSumDisplayed = false;
        double accumulatedSum = 0;
        string lastCommand = "";

        public AdderViewModel()
        {
            ClearCommand = new Command(
                execute: () =>
                {
                    HistoryString = "";
                    accumulatedSum = 0;
                    CurrentEntry = "0";
                    isSumDisplayed = false;
                    RefreshCanExecutes();
                });

            ClearEntryCommand = new Command(
                execute: () =>
                {
                    CurrentEntry = "0";
                    isSumDisplayed = false;
                    RefreshCanExecutes();
                });

            BackspaceCommand = new Command(
                execute: () =>
                {
                    CurrentEntry = CurrentEntry.Substring(0, CurrentEntry.Length - 1);

                    if (CurrentEntry.Length == 0)
                    {
                        CurrentEntry = "0";
                    }

                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return !isSumDisplayed && (CurrentEntry.Length > 1 || CurrentEntry[0] != '0');
                });

            NumericCommand = new Command<string>(
                execute: (string parameter) =>
                {
                    if (isSumDisplayed || CurrentEntry == "0")
                        CurrentEntry = parameter;
                    else
                        CurrentEntry += parameter;

                    isSumDisplayed = false;
                    RefreshCanExecutes();
                },
                canExecute: (string parameter) =>
                {
                    return isSumDisplayed || CurrentEntry.Length < 16;
                });

            DecimalPointCommand = new Command(
                execute: () =>
                {
                    if (isSumDisplayed)
                        CurrentEntry = "0.";
                    else
                        CurrentEntry += ".";

                    isSumDisplayed = false;
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return isSumDisplayed || !CurrentEntry.Contains(".");
                });

           
            AddAndExecuteCommand = new Command(
                execute: () =>
                {
                    double value = Double.Parse(CurrentEntry);
                    if (lastCommand == "")
                    {
                        CurrentEntry = value.ToString();
                        isSumDisplayed = true;
                        RefreshCanExecutes();
                    }
                    else
                    {
                        switch (lastCommand)
                        {
                            case "+":
                                {
                                    value = Double.Parse(CurrentEntry);
                                    HistoryString += value.ToString() + " + ";
                                    accumulatedSum += value;
                                    CurrentEntry = accumulatedSum.ToString();
                                    isSumDisplayed = true;
                                    RefreshCanExecutes();
                                }
                                break;
                            case "-":
                                {
                                    value = Double.Parse(CurrentEntry);
                                    HistoryString += value.ToString() + " + ";
                                    accumulatedSum -= value;
                                    CurrentEntry = accumulatedSum.ToString();
                                    isSumDisplayed = true;
                                    RefreshCanExecutes();
                                }
                                break;
                            case "*":
                                {
                                    value = Double.Parse(CurrentEntry);
                                    HistoryString += value.ToString() + " + ";
                                    accumulatedSum *= value;
                                    CurrentEntry = accumulatedSum.ToString();
                                    isSumDisplayed = true;
                                    RefreshCanExecutes();
                                }
                                break;
                            case "/":
                                {
                                    value = Double.Parse(CurrentEntry);
                                    HistoryString += value.ToString() + " + ";
                                    accumulatedSum /= value;
                                    CurrentEntry = accumulatedSum.ToString();
                                    isSumDisplayed = true;
                                    RefreshCanExecutes();
                                }
                                break;
                            default: break;
                        }
                    }
                    lastCommand = "+";
                },
                canExecute: () =>
                {
                    return !isSumDisplayed;
                });

            SubAndExecuteCommand = new Command(
                execute: () =>
                {
                    double value = Double.Parse(CurrentEntry);
                    if (lastCommand == "")
                    {
                        CurrentEntry = value.ToString();
                        isSumDisplayed = true;
                        RefreshCanExecutes();
                    }
                    else
                    {
                        switch (lastCommand)
                        {
                            case "+":
                                {
                                    value = Double.Parse(CurrentEntry);
                                    HistoryString += value.ToString() + " - ";
                                    accumulatedSum += value;
                                    CurrentEntry = accumulatedSum.ToString();
                                    isSumDisplayed = true;
                                    RefreshCanExecutes();
                                }
                                break;
                            case "-":
                                {
                                    value = Double.Parse(CurrentEntry);
                                    HistoryString += value.ToString() + " - ";
                                    accumulatedSum -= value;
                                    CurrentEntry = accumulatedSum.ToString();
                                    isSumDisplayed = true;
                                    RefreshCanExecutes();
                                }
                                break;
                            case "*":
                                {
                                    value = Double.Parse(CurrentEntry);
                                    HistoryString += value.ToString() + " - ";
                                    accumulatedSum *= value;
                                    CurrentEntry = accumulatedSum.ToString();
                                    isSumDisplayed = true;
                                    RefreshCanExecutes();
                                }
                                break;
                            case "/":
                                {
                                    value = Double.Parse(CurrentEntry);
                                    HistoryString += value.ToString() + " - ";
                                    accumulatedSum /= value;
                                    CurrentEntry = accumulatedSum.ToString();
                                    isSumDisplayed = true;
                                    RefreshCanExecutes();
                                }
                                break;
                            default: break;
                        }
                    }
                    lastCommand = "-";
                },
                canExecute: () =>
                {
                    return !isSumDisplayed;
                });

            MultiAndExecuteCommand = new Command(
                 execute: () =>
                 {
                     double value = Double.Parse(CurrentEntry);
                     if (lastCommand == "")
                     {
                         CurrentEntry = value.ToString();
                         isSumDisplayed = true;
                         RefreshCanExecutes();
                     }
                     else
                     {
                         switch (lastCommand)
                         {
                             case "+":
                                 {
                                     value = Double.Parse(CurrentEntry);
                                     HistoryString += value.ToString() + " * ";
                                     accumulatedSum += value;
                                     CurrentEntry = accumulatedSum.ToString();
                                     isSumDisplayed = true;
                                     RefreshCanExecutes();
                                 }
                                 break;
                             case "-":
                                 {
                                     value = Double.Parse(CurrentEntry);
                                     HistoryString += value.ToString() + " * ";
                                     accumulatedSum -= value;
                                     CurrentEntry = accumulatedSum.ToString();
                                     isSumDisplayed = true;
                                     RefreshCanExecutes();
                                 }
                                 break;
                             case "*":
                                 {
                                     value = Double.Parse(CurrentEntry);
                                     HistoryString += value.ToString() + " * ";
                                     accumulatedSum *= value;
                                     CurrentEntry = accumulatedSum.ToString();
                                     isSumDisplayed = true;
                                     RefreshCanExecutes();
                                 }
                                 break;
                             case "/":
                                 {
                                     value = Double.Parse(CurrentEntry);
                                     HistoryString += value.ToString() + " * ";
                                     accumulatedSum /= value;
                                     CurrentEntry = accumulatedSum.ToString();
                                     isSumDisplayed = true;
                                     RefreshCanExecutes();
                                 }
                                 break;
                             default: break;
                         }
                     }
                     lastCommand = "*";
                 },
                canExecute: () =>
                {
                    return !isSumDisplayed;
                });

            DivideAndExecuteCommand = new Command(
                 execute: () =>
                 {
                     double value = Double.Parse(CurrentEntry);
                     if (lastCommand == "")
                     {
                         CurrentEntry = value.ToString();
                         isSumDisplayed = true;
                         RefreshCanExecutes();
                     }
                     else
                     {
                         switch (lastCommand)
                         {
                             case "+":
                                 {
                                     value = Double.Parse(CurrentEntry);
                                     HistoryString += value.ToString() + " / ";
                                     accumulatedSum += value;
                                     CurrentEntry = accumulatedSum.ToString();
                                     isSumDisplayed = true;
                                     RefreshCanExecutes();
                                 }
                                 break;
                             case "-":
                                 {
                                     value = Double.Parse(CurrentEntry);
                                     HistoryString += value.ToString() + " / ";
                                     accumulatedSum -= value;
                                     CurrentEntry = accumulatedSum.ToString();
                                     isSumDisplayed = true;
                                     RefreshCanExecutes();
                                 }
                                 break;
                             case "*":
                                 {
                                     value = Double.Parse(CurrentEntry);
                                     HistoryString += value.ToString() + " / ";
                                     accumulatedSum *= value;
                                     CurrentEntry = accumulatedSum.ToString();
                                     isSumDisplayed = true;
                                     RefreshCanExecutes();
                                 }
                                 break;
                             case "/":
                                 {
                                     value = Double.Parse(CurrentEntry);
                                     HistoryString += value.ToString() + " / ";
                                     accumulatedSum /= value;
                                     CurrentEntry = accumulatedSum.ToString();
                                     isSumDisplayed = true;
                                     RefreshCanExecutes();
                                 }
                                 break;
                             default: break;
                         }
                     }
                     lastCommand = "/";
                 },
                canExecute: () =>
                {
                    return !isSumDisplayed;
                });
        }

        void RefreshCanExecutes()
        {
            ((Command)BackspaceCommand).ChangeCanExecute();
            ((Command)NumericCommand).ChangeCanExecute();
            ((Command)DecimalPointCommand).ChangeCanExecute();
            ((Command)AddCommand).ChangeCanExecute();
        }

        public string CurrentEntry
        {
            private set { SetProperty(ref currentEntry, value); }
            get { return currentEntry; }
        }

        public string HistoryString
        {
            private set { SetProperty(ref historyString, value); }
            get { return historyString; }
        }

        public ICommand ClearCommand { private set; get; }

        public ICommand ClearEntryCommand { private set; get; }

        public ICommand BackspaceCommand { private set; get; }

        public ICommand NumericCommand { private set; get; }

        public ICommand DecimalPointCommand { private set; get; }

        public ICommand AddCommand { private set; get; }

        public ICommand SubCommand { private set; get; }

        public ICommand MultiCommand { private set; get; }

        public ICommand DivideCommand { private set; get; }

        public ICommand AddAndExecuteCommand { private set; get; }

        public ICommand SubAndExecuteCommand { private set; get; }

        public ICommand MultiAndExecuteCommand { private set; get; }

        public ICommand DivideAndExecuteCommand { private set; get; }

        public void SaveState(IDictionary<string, object> dictionary)
        {
            dictionary["CurrentEntry"] = CurrentEntry;
            dictionary["HistoryString"] = HistoryString;
            dictionary["isSumDisplayed"] = isSumDisplayed;
            dictionary["accumulatedSum"] = accumulatedSum;
        }

        public void RestoreState(IDictionary<string, object> dictionary)
        {
            CurrentEntry = GetDictionaryEntry(dictionary, "CurrentEntry", "0");
            HistoryString = GetDictionaryEntry(dictionary, "HistoryString", "");
            isSumDisplayed = GetDictionaryEntry(dictionary, "isSumDisplayed", false);
            accumulatedSum = GetDictionaryEntry(dictionary, "accumulatedSum", 0.0);

            RefreshCanExecutes();
        }

        public T GetDictionaryEntry<T>(IDictionary<string, object> dictionary,
                                        string key, T defaultValue)
        {
            if (dictionary.ContainsKey(key))
                return (T)dictionary[key];

            return defaultValue;
        }
    }
}