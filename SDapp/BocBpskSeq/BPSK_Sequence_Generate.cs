﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SoftwareDesign_2017
{
    class BPSK_Sequence_Generate
    {
#region 字段
        private const int boundWidth = 30000000;//接收机的前端带宽
        private List<Point> psdSequenceReal;
        private List<Point> psdSequenceRealDb;
        private List<Point> psdSequenceForView;
        private List<Point> autocorrelationSequence;

        private int stepLength = 10000;
        #endregion
        #region 构造函数
        /// <summary>
        /// 输入参数frequence,frequenceUnit，画布大小以获取用来绘图的序列
        /// </summary>
        /// <param name="frequence">扩频码速率</param>
        /// <param name="frequenceUnit">扩频码速率的单位</param>
        /// <param name="width">画布高</param>
        /// <param name="height">画布宽</param>
        public BPSK_Sequence_Generate(double frequence, int frequenceUnit, double width, double height)
        {
            if(frequence != 0)
            {
                switch (frequenceUnit)
                {
                    case 2:
                        frequence *= 1000000;
                        break;
                    case 1:
                        frequence *= 1000;
                        break;
                    case 0:
                        frequence *= 1;
                        break;
                    default:
                        frequence *= 1;
                        break;
                }
                psdSequenceReal = BPSKPSDGenerate(frequence);
                psdSequenceForView = CoordinateTransform(psdSequenceReal, width, height);
            }            
        }
        /// <summary>
        /// 当输入参数不包含窗口的大小时根据输入的扩频码速率获取一个PSD序列
        /// </summary>
        /// <param name="frequence">扩频码速率</param>
        /// <param name="frequenceUnit">扩频码速率的单位</param>
        public BPSK_Sequence_Generate(double frequence, int frequenceUnit)
        {
            if(frequence != 0)
            {
                switch (frequenceUnit)
                {
                    case 2:
                        frequence *= 1000000;
                        break;
                    case 1:
                        frequence *= 1000;
                        break;
                    case 0:
                        frequence *= 1;
                        break;
                    default:
                        frequence *= 1;
                        break;
                }
                psdSequenceReal = BPSKPSDGenerate(frequence);
                psdSequenceRealDb = ChangeToDb(psdSequenceReal);
            }            
        }
        #endregion
        #region 方法
        /// <summary>
        /// 返回一个双极性NRZ调制信号
        /// </summary>
        /// <param name="frequence"></param>
        /// <returns></returns>
        public List<Point> BPSK_Sequence(Double frequence)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < 100; i++)
            {
                points.Add(new Point(10 + i * 10 * frequence,i % 2 * 20 + 100));
                points.Add(new Point(10 + (i + 1) * 10 * frequence, i % 2 * 20 + 100));
            }
            return points;
        }

        /// <summary>
        /// 返回一个BPSK信号（未经调制的双极性NRZ调制信号）的功率谱密度
        /// </summary>
        /// <param name="frequence">频率</param>
        /// <returns></returns>
        public List<Point> BPSKPSDGenerate(Double frequence)
        {
            List<Point> points = new List<Point>();
            Point point = new Point();
            for (int deltaI/*deltaI是为了避免零除点*/,i = -15000000; i <= (boundWidth / 2); i += stepLength)
            {
                deltaI = i + 1;
                point.X = i;
                point.Y = Math.Pow(((Math.Sin(Math.PI * deltaI / frequence)) / (Math.PI * deltaI / frequence)), 2) / frequence;
                points.Add(point);
            }
            return points;
        }

        /// <summary>
        /// 将真实的PSD点阵根据显示空间的大小调整为动态的适合窗口的点阵
        /// </summary>
        /// <param name="pointsReal"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private List<Point> CoordinateTransform(List<Point> pointsReal, double width, double height)
        {
            List<Point> pointsForView = new List<Point>();
            List<Point> pointsTemp = new List<Point>();
            List<Point> pointsRealDb = ChangeToDb(pointsReal);
            Point origin = new Point(width / 2, height);
            double yMax = 0;
            foreach (var point in pointsRealDb)
            {
                pointsTemp.Add(new Point(point.X, point.Y + 100));
                if ((point.Y + 100) > yMax)
                    yMax = point.Y + 100;
            }
            double yScale = origin.Y / yMax;
            double xScale = origin.X / (boundWidth / 2);
            foreach (var point in pointsTemp)
            {
                pointsForView.Add(new Point(point.X * xScale + origin.X, -point.Y * yScale + origin.Y));
            }
            return pointsForView;
        }

        /// <summary>
        /// 从原始的psd数据得到直接变换后的db数据，并进行了将小于-100db的数据全部截取为-100db的处理
        /// </summary>
        /// <param name="pointsReal">原始的PSD序列</param>
        /// <returns></returns>
        private List<Point> ChangeToDb(List<Point> pointsReal)
        {
            List<Point> pointsRealDb = new List<Point>();
            foreach (var point in pointsReal)
            {
                Point tempPoint = new Point(point.X, 10 * Math.Log10(point.Y));
                if (tempPoint.Y >= -100)
                {
                    pointsRealDb.Add(tempPoint);
                }
                else
                    pointsRealDb.Add(new Point(tempPoint.X, -100));
            }
            return pointsRealDb;
        }

        private List<Point> AutocorrelationSequenceGenerate(List<Point> psdSequence)
        {
            double lambda = 0;
            List<Point> rs = new List<Point>();//Rs(t)
            foreach (var point in psdSequence)
            {
                if (point.X >= -12000000 && point.X <= 12000000)  ///带宽β选择24MHz
                {
                    lambda += point.Y * stepLength;
                }
            }
            for (double i = -0.000001; i <= 0.000001001; i += 0.00000001)
            {
                double tempVal1 = 0;
                double tempVal2 = 0;
                double tempVal3 = 0;
                for (int j = 300;j <= 2700;j++)
                {
                    tempVal1 += psdSequence[j].Y * Math.Cos(2 * Math.PI * psdSequence[j].X * i) * stepLength;
                }
                for (int j = 300; j <= 2700; j++)
                {
                    tempVal2 += psdSequence[j].Y * Math.Sin(2 * Math.PI * psdSequence[j].X * i) * stepLength;
                }
                tempVal3 = Math.Sqrt(Math.Pow(tempVal1, 2) + Math.Pow(tempVal2, 2)) / lambda;
                rs.Add(new Point(i, tempVal3));
            }
            return rs;
        }
        #endregion
        #region 属性
        /// <summary>
        /// 获取一个未经过坐标变换的BPSK信号的功率谱密度点序列
        /// </summary>
        public List<Point> GetPsdSequenceReal
        {
            get { return psdSequenceReal; }
        }

        /// <summary>
        /// 获取一个未经过坐标变换的BPSK信号的自相关函数点序列
        /// </summary>
        public List<Point> GetAutocorrelationSequence
        {
            get
            {
                if (autocorrelationSequence == null)
                    return autocorrelationSequence = AutocorrelationSequenceGenerate(psdSequenceReal);
                else
                    return autocorrelationSequence;
            }
        }

        /// <summary>
        /// 获取一个DB变换后，但未适应窗口的BPSK信号的功率谱密度点序列
        /// </summary>
        public List<Point> GetPsdSequenceRealDb
        {
            get { return psdSequenceRealDb; }
        }

        /// <summary>
        /// 获取一个坐标变换后，适合画布大小的BPSK信号的功率谱密度点序列
        /// </summary>
        public List<Point> GetPsdSequenceForView
        {
            get { return psdSequenceForView; }
        }
        #endregion
    }
}
