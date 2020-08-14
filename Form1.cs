using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private String paramFromFile = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Focas1.focas_ret ret = (Focas1.focas_ret)Focas1.cnc_allclibhndl3("192.168.18.8", 8193, 5, out cncHandle); //眔library handle
                //Focas1.focas_ret ret = (Focas1.focas_ret)Focas1.cnc_allclibhndl3(textBox_IP.Text, 8193, 5, out cncHandle); //眔library handle
                //textBox_IP
                if (ret != Focas1.focas_ret.EW_OK)
                {
                    this.rdpara.Enabled = false;
                    this.btnFileDown.Enabled = false;
                    this.btnUpload.Enabled = false;
                    throw new Exception("Can't connect to CNC controller!");
                }
                else
                {
                    this.rdpara.Enabled = true;
                    this.btnFileDown.Enabled = true;
                    this.btnUpload.Enabled = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (opdCNC.ShowDialog()== DialogResult.OK)
            {
                txtFilePath.Text = opdCNC.FileName;

                StreamReader sr = new StreamReader(txtFilePath.Text, Encoding.Default);
                StringBuilder sbtxt = new StringBuilder();
                String line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    sbtxt.Append(line);
                    sbtxt.Append("\n");
                }
                sr.Close();
                paramFromFile = sbtxt.ToString();
                MessageBox.Show(paramFromFile);
            }
        }

        private void btnFileDown_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(paramFromFile))
            {
                int len;
                int n;
                short ret;

                short ret1;
                short num = 1;
                //删除程序文件（删除的文件不能是主程序文件）
                ret1 = Focas1.cnc_delete(cncHandle, num);
                switch (ret1)
                {
                    case Focas1.EW_OK:
                        MessageBox.Show(string.Format("PROGRAM O%d has been deleted.\n", num));
                        break;
                    case (short)Focas1.focas_ret.EW_DATA:
                        MessageBox.Show(string.Format("PROGRAM O%d doesn't exist.\n", num));
                        break;
                    case (short)Focas1.focas_ret.EW_PROT:
                        MessageBox.Show(string.Format("PROTECTED.\n"));
                        break;
                    case (short)Focas1.focas_ret.EW_BUSY:
                        MessageBox.Show(string.Format("REJECTED.\n"));
                        break;
                }


                ret = Focas1.cnc_dwnstart3(cncHandle, 0);
                if (ret== -1)
                {
                    ret = Focas1.cnc_dwnend3(cncHandle);
                    return;
                }
                if (ret != Focas1.EW_OK) {
                    MessageBox.Show("下发参数失败");
                    return;
                }

                len = paramFromFile.Length;
                while (len > 0)
                {
                    n = len;
                    ret = Focas1.cnc_download3(cncHandle,ref n, paramFromFile);
                    if (ret == (short)Focas1.focas_ret.EW_BUFFER)
                    {
                        continue;
                    }
                    if (ret == Focas1.EW_OK)
                    {
                        paramFromFile += n;
                        len -= n;
                    }
                    if (ret != Focas1.EW_OK)
                    {
                        break;
                    }
                }
                ret = Focas1.cnc_dwnend3(cncHandle);

                MessageBox.Show("下发完成!");

            }
            else
            {
                MessageBox.Show("请选择参数文件");
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

            StringBuilder sbParamFile = new StringBuilder();
            int BUFSIZE = 1280;
            char[] buf = new char[BUFSIZE + 1];
            short ret;
            int len;
            ret = Focas1.cnc_upstart3(cncHandle, 0, 1,1);
            if (ret != Focas1.EW_OK)
            {
                MessageBox.Show("读取参数文件失败");
                return;
            }
            do
            {
                len = BUFSIZE;
                ret = Focas1.cnc_upload3(cncHandle, ref len, buf);
                if (ret == (short)Focas1.focas_ret.EW_BUFFER)
                {
                    continue;
                }
                if (ret == Focas1.EW_OK)
                {
                    buf[len] = '\0';
                    for(int i=0;i<len;i++)
                    {
                         sbParamFile.Append(buf[i]);                        
                    }
                    saveFile(sbParamFile.ToString());
                }
                if (buf[len - 1] == '%')
                {
                    break;
                }
            } while (ret == Focas1.EW_OK);
            ret = Focas1.cnc_upend3(cncHandle);
            MessageBox.Show(sbParamFile.ToString());
        }

        private void saveFile(string file)
        {
            FileStream fs = new FileStream("E:\\1.NC",FileMode.Create);
            byte[] data = System.Text.Encoding.Default.GetBytes(file);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }

        private void btnSetMain_Click(object sender, EventArgs e)
        {
            //设置当前主程序
            short ret = Focas1.cnc_pdf_slctmain(cncHandle, "//CNC_MEM/USER/PATH1/O0003");
            if (ret==Focas1.EW_OK)
            {
                MessageBox.Show("设置成功");
            }
        }

        private void btnToolRead_Click(object sender, EventArgs e)
        {
            

            //刀具生命周期
            //short data_num = 1;
            //Focas1.IODBTLMNG iod = new Focas1.IODBTLMNG();
            //short ret = Focas1.cnc_rdtool(cncHandle, 1, ref data_num, iod);
            //if (ret == Focas1.EW_OK)
            //{
            //    MessageBox.Show("结果：" + iod.data1.custom1);
            //}

            //形状补偿读取
            StringBuilder sbShape = new StringBuilder();
            Focas1.ODBTOFS iod = new Focas1.ODBTOFS();
            short ret = Focas1.cnc_rdtofs(cncHandle, 1, 1,8, iod);//形状 X轴
            if (ret == Focas1.EW_OK)
            {
                sbShape.AppendLine("形状X轴结果：" + iod.data/1000.0);
            }

            ret = Focas1.cnc_rdtofs(cncHandle, 1, 3, 8, iod);//形状 Z轴
            if (ret == Focas1.EW_OK)
            {
                sbShape.AppendLine("形状Z轴结果：" + iod.data / 1000.0);
            }

            ret = Focas1.cnc_rdtofs(cncHandle, 1, 9, 8, iod);//形状 Y轴
            if (ret == Focas1.EW_OK)
            {
                sbShape.AppendLine("形状Y轴结果：" + iod.data / 1000.0);
            }

            ret = Focas1.cnc_rdtofs(cncHandle, 1, 5, 8, iod);//形状 半径R
            if (ret == Focas1.EW_OK)
            {
                sbShape.AppendLine("半径R结果：" + iod.data / 1000.0);
            }

            ret = Focas1.cnc_rdtofs(cncHandle, 1, 7, 8, iod);//形状 T
            if (ret == Focas1.EW_OK)
            {
                sbShape.AppendLine("形状T结果：" + iod.data );
            }

            //磨损补偿读取
            ret = Focas1.cnc_rdtofs(cncHandle, 1, 0, 8, iod);//磨损 X轴
            if (ret == Focas1.EW_OK)
            {
                sbShape.AppendLine("磨损X轴结果：" + iod.data / 1000.0);
            }

            ret = Focas1.cnc_rdtofs(cncHandle, 1, 2, 8, iod);//磨损 Z轴
            if (ret == Focas1.EW_OK)
            {
                sbShape.AppendLine("磨损Z轴结果：" + iod.data / 1000.0);
            }

            ret = Focas1.cnc_rdtofs(cncHandle, 1, 8, 8, iod);//磨损 Y轴
            if (ret == Focas1.EW_OK)
            {
                sbShape.AppendLine("磨损Y轴结果：" + iod.data / 1000.0);
            }

            ret = Focas1.cnc_rdtofs(cncHandle, 1, 4, 8, iod);//磨损 半径R
            if (ret == Focas1.EW_OK)
            {
                sbShape.AppendLine("磨损R结果：" + iod.data / 1000.0);
            }

            ret = Focas1.cnc_rdtofs(cncHandle, 1, 6, 8, iod);//磨损 T
            if (ret == Focas1.EW_OK)
            {
                sbShape.AppendLine("磨损T结果：" + iod.data );
            }
            MessageBox.Show(sbShape.ToString());
        }

        private void btnToolWrite_Click(object sender, EventArgs e)
        {
            StringBuilder sbShape = new StringBuilder();
            short ret = Focas1.cnc_wrtofs(cncHandle, 1, 1, 8, 1);//形状 X轴
            

            ret = Focas1.cnc_wrtofs(cncHandle, 1, 3, 8, 1);//形状 Z轴
            
            ret = Focas1.cnc_wrtofs(cncHandle, 1, 9, 8, 1);//形状 Y轴
            

            ret = Focas1.cnc_wrtofs(cncHandle, 1, 5, 8, 1);//形状 半径R
            

            ret = Focas1.cnc_wrtofs(cncHandle, 1, 7, 8, 1);//形状 T
           

            //磨损补偿读取
            ret = Focas1.cnc_wrtofs(cncHandle, 1, 0, 8, 1);//磨损 X轴
           

            ret = Focas1.cnc_wrtofs(cncHandle, 1, 2, 8, 1);//磨损 Z轴
            

            ret = Focas1.cnc_wrtofs(cncHandle, 1, 8, 8, 1);//磨损 Y轴
           

            ret = Focas1.cnc_wrtofs(cncHandle, 1, 4, 8, 1);//磨损 半径R
           

            ret = Focas1.cnc_wrtofs(cncHandle, 1, 6, 8, 1);//磨损 T
            
            MessageBox.Show("设置完成");
        }

        private void btnRunStatus_Click(object sender, EventArgs e)
        {
            int count = 0;
            Focas1.IODBTIMER time = new Focas1.IODBTIMER();
            short ret = Focas1.cnc_gettimer(cncHandle,time);
            if (ret == Focas1.EW_OK)
            {
                MessageBox.Show(string.Format("当前时间:{0}年{1}月{2}日 {3}:{4}:{5}",time.date.year,time.date.month,time.date.date,time.time.hour,time.time.minute,time.time.second));
            }

        }
    }
}