using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Json;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Resources;
using System.IO;





namespace SmartDeviceProject1
{

    public partial class Form1 : Form
    {

        //lock
        private System.Object lockThis = new System.Object();
        private System.Object lockOld = new System.Object();

        //String device_id = "testMachine1";
        
        bool isOpen;
        //온도
        private double temperature;
                //온도 목표값
        private double tgtTmp;
        private double tgtHum;
        private double tgtO;
        private double tgtCo;

        private double oldTmp;
        private double oldCo;
        private double oldHum;
        private double oldO;

        //농도
        private double oxygen;
        private double carbonDiOxy;
        //습도
        private double hum;



        //fanspeed
        private int fan1speed;


        //fanstate
        private int fan1state = 0;

        //resousrce
        private Image img1;
        private Image img2;
        private ResourceManager rm;


        


        void sendJsonLog(String log)
        {
            lock (lockThis)
            {

                String json = "{\"device_id\": \"zxcv1234\",\"log\": \"" + log + "\" ,"+
                              " \"temperature\" : \""+ temperature.ToString("N1") + "\" ,"+
                              " \"CO2\" : \"" + carbonDiOxy.ToString("N1") + " \" ," +
                              " \"O2\" : \"" + oxygen.ToString("N1") + " \" ," +
                              " \"humidity\" : \"" + hum.ToString("N1") + " \" ," +
                              " \"log_time\" : \"" + DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss") + "\"}";
                byte[] data = Encoding.UTF8.GetBytes(json);

                //string label = "";
                HttpWebRequest logQuery = (HttpWebRequest)WebRequest.Create("http://dev.huni.org:8000/api/log/");
                HttpWebResponse logResponse;
                logQuery.Credentials = CredentialCache.DefaultCredentials;
                logQuery.Method = "POST";
                logQuery.ContentType = "application/json; charset=UTF-8";
                logQuery.Accept = "application/json";
                //label += "ready";
                //LogText.Text = label;

                logQuery.ContentLength = data.Length;

                using (var streamWriter = logQuery.GetRequestStream())
                {
                    streamWriter.Write(data, 0, data.Length);
                    streamWriter.Flush();
                }

                using (logResponse = (HttpWebResponse)logQuery.GetResponse())
                {
                    Stream respPostStream = logResponse.GetResponseStream();
                    StreamReader readerPost = new StreamReader(respPostStream, Encoding.GetEncoding("UTF-8"), true);

                    string resResult = readerPost.ReadToEnd();
                }
                
            }
            //send


            //data.Clear();


        }


        void sendJsonRequest()
        {
            lock (lockThis)
            {

                //JsonObjectCollection data = new JsonObjectCollection();
                HttpWebRequest logQuery = (HttpWebRequest)WebRequest.Create("http://dev.huni.org:8000/api/request/?device_id=zxcv1234");
                HttpWebResponse logResponse;
                logQuery.Credentials = CredentialCache.DefaultCredentials;

                logQuery.Method = "GET";
                logQuery.Accept = "application/json";

                using (logResponse = (HttpWebResponse)logQuery.GetResponse())
                {
                    Stream respPostStream = logResponse.GetResponseStream();
                    StreamReader readerPost = new StreamReader(respPostStream, Encoding.GetEncoding("UTF-8"), true);

                    char[] del = { ',' };
                    string resResult = readerPost.ReadToEnd();
                    resResult = resResult.ToLower();
                    resResult = resResult.Replace(" ", "");
                    resResult = resResult.Replace("\"", "");
                    resResult = resResult.Replace(":", "");
                    resResult = resResult.Replace("{", "");
                    resResult = resResult.Replace("}", "");
                                  
                    string[] words = resResult.Split(del);

                    if (words.Length > 2)
                    {
                        words[3] = words[3].Replace("value","");

                        if (resResult.Contains("setco2")) { tgtCo = Double.Parse(words[3].ToString()); }
                        else if (resResult.Contains("seto2")) { tgtO = Double.Parse(words[3].ToString()); }
                        else if (resResult.Contains("sethumidity")) { tgtHum = Double.Parse(words[3].ToString()); }
                        else if (resResult.Contains("settemperature")) { tgtTmp = Double.Parse(words[3].ToString()); }
                        Req.Interval = 3000;
                    }
                    else {
                        Req.Interval = 25000;
                    }

                    //Console.WriteLine(resResult);
                }

            }
            //send


            //data.Clear();


        }




        private void init(){
            rm = SmartDeviceProject1.Properties.Resources.ResourceManager;
            img1 = (Image)rm.GetObject("one");
            img2 = (Image)rm.GetObject("two");

            temperature = -14.0;

            tgtTmp = -18.0;
            tgtCo = 5.0;
            tgtO = 6.0;
            tgtHum = 30.0;


            hum = 40.0;
            oxygen = 21.0;
            carbonDiOxy = 5.0;


            oldCo = carbonDiOxy;
            oldO = oxygen;
            oldHum = hum;
            oldTmp = temperature;

            fan1speed = 3;

            
            
            isOpen = false; //0== close;

        }


        public Form1()
        {
            InitializeComponent();
            // http 연결 설정;
            

            //확인이 되면.
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            init();


            
            
            smartTimer1_Tick(sender, e);

            Fan_one_timer_Tick(sender, e);

            Fan_one_timer.Interval = fan1speed*100;

            smartTimer1.Interval = 10000;
            smartTimer1.StartTime = 10000;
            
            smartTimer1.Start();
            
            Fan_one_timer.Start();

            Refresh_Tick(sender, e);
            refreshLog.Interval = 10015;
            refreshLog.Start();
            
            Req_Tick(sender, e);
            Req.Interval = 25000;
            Req.Start();
            
            DoorStatus.Text = "장비 문이 닫힘";


            this.BtnClose.Enabled = false;
            this.Btnopen.Enabled = true;
                      


        }

        private void smartTimer1_Tick(object sender, EventArgs e)
        {
            lock (lockOld)
            {
                oldCo = carbonDiOxy;
                oldO = oxygen;
                oldHum = hum;
                oldTmp = temperature;

            }


                //랜덤하게 데이터 변이주기;
                Random r = new Random();
                //int n = r.Next(0, 100);
                if (isOpen)
                {
                    temperature += 0.1;
                    hum += 0.2;
                }
                if (fan1speed > 3)
                {
                    temperature += 0.5;
                }
                else if (fan1speed < 3)
                {
                    temperature -= 0.5;
                    hum *= 0.99;
                }

                //fanspeedchngd
                if (tgtTmp == temperature)
                {
                    fan1speed = 3;
                }
                else if (tgtTmp > temperature)
                {
                    fan1speed = 5;
                }
                else if (tgtTmp < temperature)
                {
                    fan1speed = 1;
                }


                Fan_one_timer.Interval = 100 * fan1speed;

                //smartLabel1.Text = "cooling room : " + refTmp.ToString("N2") + " C\nTarget Temp : " + tgtRefTmp.ToString("N2") + " C\nFanspeed : " + fan1speed;
                this.Text = "tmp : " + tgtTmp.ToString("N1") + " C" + ", CO2 : " + tgtCo.ToString("N1") + " %, " + "O2 : " + tgtO.ToString("N1") + " %, " + "hum : " + tgtHum.ToString("N1") + " %";
                Carbon.Text = carbonDiOxy.ToString("N1") + " %";
                Oxy.Text = oxygen.ToString("N1") + " %";
                Temp.Text = temperature.ToString("N1") + " C";
                Humi.Text = hum.ToString("N1") + " %";
            
            //sendJsonLog("값 갱신 ( " + temperature.ToString("N1") + " C )");

        }




                        
        private void Fan_one_timer_Tick(object sender, EventArgs e)
        {


            if (fan1state == 0)
            {

                pictureBox1.Image = img1;
                fan1state = 1;

            }
            else {
                pictureBox1.Image = img2;
                fan1state = 0;
            }
        }

        private void Btnopen_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                
                hum += 0.1;
                Humi.Text = hum.ToString("N1") + " %";
                DoorStatus.Text = "장비 문이 열림";
                sendJsonLog("장비 문이 열림");
                isOpen = true;
                this.Btnopen.Enabled = false;
                this.BtnClose.Enabled = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (isOpen)
            {
                
                DoorStatus.Text = "장비 문이 닫힘";
                sendJsonLog("장비 문이 닫힘");
                isOpen = false;
                this.BtnClose.Enabled = false;
                this.Btnopen.Enabled = true;
            }

        }

        private void Req_Tick(object sender, EventArgs e)
        {
            sendJsonRequest();
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            string log = "값 변경 (";
            lock (lockOld)
            {
                if (!oldTmp.ToString("N1").Equals(temperature.ToString("N1")))
                {
                    log = log + " Temperature : " + temperature.ToString("N1") + " C ";
                }
                if (!oldCo.ToString("N1").Equals(carbonDiOxy.ToString("N1")))
                {
                    log = log + " CO2 : " + carbonDiOxy.ToString("N1") + " % ";
                }
                if (!oldO.ToString("N1").Equals(oxygen.ToString("N1")))
                {
                    log = log + " O2 : " + oxygen.ToString("N1") + " % ";
                }
                if (!oldHum.ToString("N1").Equals(hum.ToString("N1")))
                {
                    log = log + " Humidity : " + hum.ToString("N1") + " %";
                }

                LogText.Text = log + " )";

                if (log.Equals("값 변경 ("))
                {
                    sendJsonLog("정기 갱신");
                    LogText.Text = "정기갱신";
                }
                else
                {
                    sendJsonLog(log + " )");

                }
            }

        }




    }
}