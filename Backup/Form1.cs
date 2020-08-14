using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Focas1;

namespace GetAlmMsg
{

    public partial class Form1 : Form
    {
        ushort cncHandle = 0;
        private short preState = 0;
        private Focas1.ODBST cncStatus = new Focas1.ODBST();
        private Focas1.ODBAHIS alarmHis = new Focas1.ODBAHIS();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Focas1.focas_ret ret = (Focas1.focas_ret)Focas1.cnc_allclibhndl3("192.168.0.31", 8193, 5, out cncHandle); //取得library handle
                //Focas1.focas_ret ret = (Focas1.focas_ret)Focas1.cnc_allclibhndl3(textBox_IP.Text, 8193, 5, out cncHandle); //取得library handle
                //textBox_IP
                if (ret != Focas1.focas_ret.EW_OK)
                {
                    this.rdpara.Enabled = false;
                    throw new Exception("Can't connect to CNC controller!");
                }
                else
                {
                    this.rdpara.Enabled = true;
                    btnConnect.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message");
            }

        }

        private void butGetAlmNo_Click(object sender, EventArgs e)
        {
           DoAlmRecord(false);
           //short almNo = 0;
           //string almDate = "";
           //string almMsg = "";
           //almMsg = GetAlarmMessage(ref almNo, ref almDate);
           //textBox1.Text = almDate;
           //textBox2.Text = almNo.ToString();
           //textBox3.Text = almMsg;

           //DoAlmRecord(true);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           if ( cncHandle != 0 )
              Focas1.cnc_freelibhndl(cncHandle);
        }

        private void AlmTimer1_Tick(object sender, EventArgs e)
        {
           Focas1.cnc_statinfo(cncHandle, cncStatus);

           //Record the start time of Alarm
           if ( cncStatus.alarm==1 && preState==0 )
           {
              DoAlmRecord(false);

              short almNo = 0;
              string almStartTime = "";
              string almMsg = "";
              almMsg = GetAlarmMessage(ref almNo, ref almStartTime);
              textBox1.Text = almStartTime;
              textBox2.Text = almNo.ToString();
              textBox3.Text = almMsg;

              DoAlmRecord(true);
           }

           //Record the end time of Alarm
           if ( cncStatus.alarm==0 && preState==1 )
           {
              DoAlmRecord(false);

              //short almNo = 0;
              //string buf = "";
              //string almMsg = "";
              string almEndTime = "";
              DateTime almTime = DateTime.Now;
              //almMsg = GetAlarmMessage(ref almNo, ref buf);
              almEndTime = almTime.Year.ToString("D4") +
                           almTime.Month.ToString("D2") +
                           almTime.Day.ToString("D2") +
                           almTime.Hour.ToString("D2") +
                           almTime.Minute.ToString("D2") +
                           almTime.Second.ToString("D2");

              textBox1.Text = almEndTime;
              //textBox2.Text = almNo.ToString();
              //textBox3.Text = almMsg;

              DoAlmRecord(true);
           }

           preState = cncStatus.alarm;
        }

        public void DoAlmRecord(bool flag)
        {
           short ret = -1;
           if (flag == false)
              ret = Focas1.cnc_stopophis(cncHandle);
           else
              ret = Focas1.cnc_startophis(cncHandle);
        }

        public string GetAlarmMessage(ref short almNo, ref string almTime)
        {
           ushort almCount = 0;
           Focas1.cnc_rdalmhisno(cncHandle, out almCount);
           ushort sNum = almCount;
           ushort eNum = almCount;
           ushort len = (ushort)(6 + 48 * (eNum - sNum + 1));
           Focas1.cnc_rdalmhistry(cncHandle, sNum, eNum, len, alarmHis);
           almNo = alarmHis.alm_his.data1.alm_no;
           almTime = String.Format("{0:00}", alarmHis.alm_his.data1.year + 2000)
                + String.Format("{0:00}", alarmHis.alm_his.data1.month)
                + String.Format("{0:00}", alarmHis.alm_his.data1.day)
                + String.Format("{0:00}", alarmHis.alm_his.data1.hour)
                + String.Format("{0:00}", alarmHis.alm_his.data1.minute)
                + String.Format("{0:00}", alarmHis.alm_his.data1.second);
           return alarmHis.alm_his.data1.alm_msg;
        }

       public Focas1.IODBPSD_1 prmDataNoAxis = new Focas1.IODBPSD_1();
       public Focas1.IODBPSD_3 prmData = new Focas1.IODBPSD_3();

       private void btnSetParam_Click(object sender, EventArgs e)
       {
			 short len = 0;
          short prmNum = 20;
          //short type = 25;//11001
          //byte[] val = new byte[3] {1,2,3};
          byte  value = 5;
           
			 //if((type & 4) == 0)
			 //{
             len=4+1;//datano(2 bytes)+type(2 bytes)+cdata(1 byte)
             //prmData.datano = prmNum;
             //prmData.type = type;
             prmDataNoAxis.datano = prmNum;
             prmDataNoAxis.type = 0;//No axis

             //if ((type & 3) == 1)
             //{
                //for (int i = 0; i < 3; i++)
                //   prmData.cdatas[i] = val[i];
                prmDataNoAxis.cdata = value;
             //}
				 
             //Focas1.focas_ret ret = (Focas1.focas_ret)Focas1.cnc_wrparam(cncHandle, len, prmData);
             Focas1.focas_ret ret = (Focas1.focas_ret)Focas1.cnc_wrparam(cncHandle, len, prmDataNoAxis);
             if (ret == Focas1.focas_ret.EW_OK)
                btnSetParam.Enabled = false;
          //}
       }

        private void rdpara_Click(object sender, EventArgs e)
        {
            short ret, idx, axno;
            short start = 1, end1 = 1000, axno1 = -1, length = 10000;
            Focas1.ODBSYS info = new Focas1.ODBSYS();
            Focas1.IODBPSD_1 param = new Focas1.IODBPSD_1();
            Focas1.IODBPSD_3 param1 = new Focas1.IODBPSD_3();
            Focas1.ODBPARANUM paranum = new Focas1.ODBPARANUM();
            ret = Focas1.cnc_rdparanum(cncHandle, paranum);
            //start = (short)(paranum.para_min+1);
            //end1 = (short)paranum.total_no;
            ret = Focas1.cnc_rdparar(cncHandle, ref start, end1, ref axno1, ref length, param1);

            Focas1.ODBPARAIF paraif = new Focas1.ODBPARAIF();
            Focas1.cnc_sysinfo(cncHandle,info);
            axno = 3;
            Focas1.cnc_rdparainfo(cncHandle, 0, 1, paraif);
            bool withaxs;
            while (paraif.next_no != 0)
            {
                Focas1.cnc_rdparainfo(cncHandle, paraif.next_no, 1, paraif);
                string temp_string = Convert.ToString(paraif.info.info1.prm_type,2);
                int temp_type = Convert.ToInt16(temp_string[temp_string.Length - 1]) - 48;
                if (temp_string.Length>1)
                    temp_type = temp_type + (Convert.ToInt16(temp_string[temp_string.Length - 2]) - 48)*2;
                if (temp_string.Length > 2)
                    withaxs = Convert.ToInt16(temp_string[temp_string.Length - 3]) == 48;
                else
                    withaxs = false;
                if (withaxs)
                {
                    ret = Focas1.cnc_rdparam(cncHandle, paraif.info.info1.prm_no, -1, (short)(4 + 1 * Focas1.MAX_AXIS), param);//(short)(4 + 1 * MAX_AXIS)

                }
                else
                {
                    ret = Focas1.cnc_rdparam(cncHandle, paraif.info.info1.prm_no, -1, (short)(4 + 1 * Focas1.MAX_AXIS), param1);//(short)(4 + 1 * MAX_AXIS)
                }
            }
            for (idx = 0; idx < axno; idx++)
            {
                //printf("#%d", idx + 1);
                //printf("%c\n", param.u.cdatas[idx]);
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}