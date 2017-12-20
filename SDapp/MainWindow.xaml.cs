﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;

namespace SoftwareDesign_2017
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Context context = new Context();

        public MainWindow()
        {
            DataContext = context;
            InitializeComponent();
        }

        #region Event of button        
        //选项卡1中的提交按钮（tabItem1_Button1）被点击时触发的事件
        private void Submmit_Button_Click(object sender, RoutedEventArgs e)
        {
            Paint paint = new Paint();

            var control = sender as Button;
            if (control == null)
                return;
            
            try
            {
                if(control.Name == "BpskSubmmit_Button")
                {
                    BPSK_Sequence_Generate bpskSequenceGenerate = new BPSK_Sequence_Generate(Convert.ToDouble(context.FrequenceBpsk), Convert.ToInt32(context.FrequenceUnit), tabItem1_canvas.Width, tabItem1_canvas.Height);//利用TextBox中输入的参数获取一个序列
                    context.pointsForBpsk = bpskSequenceGenerate.GetPsdSequenceForView;
                    if (context.pointsForBpsk != null)//如果正确获取了该序列，则将其绘图
                    {
                        context.visualForBpsk = paint.DrawVisual(context.pointsForBpsk, true, false, Type.Line);
                        tabItem1_canvas.RemoveAll();
                        tabItem1_canvas.AddVisual(context.visualForBpsk);
                    }
                    else
                        MessageBox.Show("请先输入参数再画图", "提示");
                }                    
                else if (control.Name == "BocSubmmit_Button")
                {
                    BOC_Sequence_Generate bocSequenceGenerate = new BOC_Sequence_Generate(Convert.ToInt32(context.Alpha), Convert.ToInt32(context.Beta), tabItem2_canvas.Width, tabItem2_canvas.Height);//利用TextBox中输入的参数获取一个序列
                    context.pointsForBoc = bocSequenceGenerate.GetPsdSequenceForView;
                    if (context.pointsForBoc != null)//如果正确获取了该序列，则将其绘图
                    {
                        context.visualForBoc = paint.DrawVisual(context.pointsForBoc, true, false, Type.Line);
                        tabItem2_canvas.RemoveAll();
                        tabItem2_canvas.AddVisual(context.visualForBoc);
                    }
                    else
                        MessageBox.Show("请先输入参数再画图", "提示");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("输入浮点数");
            }
        }

        private void SavePic_Button_Click(object sender, RoutedEventArgs e)
        {
            string url;//将要保存文件的路径

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPG格式(*.jpg)|*.jpg|JPEG格式(*.jpeg)|*.jpg|PNG格式(*.png)|*.png";
            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.ShowDialog();
            url = saveFileDialog.FileName;

            SavePic savePic = new SavePic();
            savePic.SaveVisual(context.visualForBpsk, url);
        }
        #endregion
#region Event of textBox
        //选项卡1中的文本框获取焦点时触发的事件
        private void tabItem1_TextBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            var control = sender as TextBox;
            if (control == null)
                return;
            control.SelectAll();
        }

        //当鼠标左键在选项卡1中的文本框中按下时触发的事件
        private void tabItem1_TextBox1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var control = sender as TextBox;
            if (control == null)
                return;
            Keyboard.Focus(control);
            e.Handled = true;
        }

        //选项卡1中的保存图片按钮被按下时触发的事件

        #endregion
    }
}
