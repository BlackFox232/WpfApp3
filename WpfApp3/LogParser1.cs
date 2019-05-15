using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Wpf.CartesianChart.Basic_Bars
{
    
        internal class LogParser : IWorkWithLog
        {
            Regex regexOpen = new Regex("Open");
            Regex regexClose = new Regex("Close");

            public List<string> ReadLog(string logAdress)
            {
                List<string> log = new List<string>();
                int cnt = 0;
                using (StreamReader sr = new StreamReader(logAdress, Encoding.GetEncoding(1251)))
                    //log = sr.ReadToEnd();
                    while (sr.EndOfStream != true)
                    {
                        log.Add(sr.ReadLine());
                        cnt++;
                    }
                return log;
            }//прочитать лог

            public List<string> FindWorkSections(List<string> log)
            {

                List<string> workSections = new List<string>();

                foreach (var item in log)
                {
                    if (regexOpen.IsMatch(item) || regexClose.IsMatch(item))
                    {
                        workSections.Add(item);
                    }
                }
                return workSections;
            }//вырезка Open/Close из всего лога  

            public int[][] GetPoints(List<string> workSections)
            {
                int time;
                int[][] interval = new int[2][];
                //int[] intervalCloses = new int[11];
                interval[0] = new int[11];
                interval[1] = new int[11];

                int currentInterval = 0;

                foreach (var item in workSections)
                {
                    Regex timeInterval;
                    time = 8;

                    for (int i = 0; i < 11; i++)
                    {
                        if (time == 8 || time == 9)
                        {
                            timeInterval = new Regex($"0{time}:" + "[0-9]{2}:" + "[0-9]{2}");
                        }
                        else
                        {
                            timeInterval = new Regex($"{time}:" + "[0-9]{2}:" + "[0-9]{2}");
                        }


                        if (timeInterval.IsMatch(item))
                        {

                            //interval[i]++;

                            if (regexOpen.IsMatch(item))
                            {
                                interval[0][i]++;
                                currentInterval++;
                            }
                            else
                            {
                                interval[1][i]++;
                                currentInterval++;
                            }
                        }

                        time++;
                    }
                }
                return interval;
            } // 

            //public List<DateTime> ParseTime(List<string> workSections)
            //{
            //    List<DateTime> currentTime = new List<DateTime>();

            //    regexOpen = new Regex("[0-9]{2}" + ":" + "[0-9]{2}" + ":" + "[0-9]{2}");

            //    foreach (var item in workSections)
            //    {
            //        var mt = regexOpen.Match(item);

            //        if (mt.Success)
            //        {
            //            currentTime.Add(Convert.ToDateTime((mt.Value)));
            //        }
            //    }

            //    return currentTime;
            //}//Вырезка времени из лога

            public string[] GetNumberCalls(string[] timeCall, List<string> workSections) // Получаем количество вызовов
            {
                string[] calls = new string[9];

                int current;

                int cnt = 0;

                for (int i = 0; i < calls.Length; i++)
                {
                    calls[i] = "Time: =";
                }

                for (int i = 0; i < workSections.Count; i++)
                {
                    if (regexOpen.IsMatch(workSections[i]))
                    {

                    }
                }

                return calls;
            }

            public string[] GetTimeCall(string[] numberCall, List<string> workSections)
            {
                string[] calls = new string[9];

                for (int i = 0; i < calls.Length; i++)
                {
                    calls[i] = "";
                }

                return calls;
            } // Время вызовов
        }
    }