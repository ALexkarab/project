using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimplexMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SetGrid_Click(object sender, EventArgs e)
        {
            //задаем параметры таблицы для отображения
            matrix.RowCount = int.Parse(restrCount.Text) + 1;
            matrix.ColumnCount = int.Parse(varCount.Text) + 1;
            matrix.Height = 20*matrix.RowCount + 15;
            matrix.RowHeadersWidth = 60;

            //задаем имена рядов
            for (int i = 0; i < matrix.RowCount-1; i++) 
            {
                matrix.Rows[i].HeaderCell.Value = "0=";
            }
            matrix.Rows[matrix.RowCount - 1].HeaderCell.Value = "F=";

            //задаем имена колонок
            matrix.Columns[0].HeaderCell.Value = "1";
            for (int i = 1; i < matrix.ColumnCount; i++) 
            {
                matrix.Columns[i].HeaderCell.Value = "-x" + i;
            }
        }
        private void CopyToPastMatrix() 
        {
            pastMatrix.RowCount = matrix.RowCount;
            pastMatrix.ColumnCount = matrix.ColumnCount;
            pastMatrix.Height = 20 * pastMatrix.RowCount + 15;
            pastMatrix.RowHeadersWidth = 60;

            //задаем имена рядов
            for (int i = 0; i < pastMatrix.RowCount; i++)
            {
                pastMatrix.Rows[i].HeaderCell.Value = matrix.Rows[i].HeaderCell.Value;
            }

            //задаем имена колонок
            for (int i = 0; i < matrix.ColumnCount; i++)
            {
                pastMatrix.Columns[i].HeaderCell.Value = matrix.Columns[i].HeaderCell.Value;
            }

            for (int i = 0; i < matrix.ColumnCount; i++) 
            {
                for (int j = 0; j < matrix.RowCount; j++) {
                    pastMatrix[i, j].Value = matrix[i, j].Value;
                }
            }
        }

        private void SolveSystem_Click(object sender, EventArgs e)
        {
            CopyToPastMatrix();
            if (!isBasisSolution())
            {
                FindBasisSolution();
            }
            else {
                if (!isBasePlan())
                {
                    FindBasePlan();
                }
                else 
                {
                    if (!isOptimized())
                    {
                        Optimize();
                    }
                }
            }            
        }

        private bool isBasisSolution() {
            bool isBasisSolution = true;
            if (matrix.ColumnCount != int.Parse(varCount.Text) - int.Parse(restrCount.Text) + 1) 
            {
                isBasisSolution = false;
            }
            if (isBasisSolution)
            {
                MessageLog("Базовое решение");
            }
            else 
            {
                MessageLog("Нет базового решения");
            }
            return isBasisSolution;
        }

        private void FindBasisSolution() 
        {
            int rowNum = -1;
            int colNum = -1;
            for (int i = 0; i < matrix.RowCount - 1; i++)
            {
                if (matrix.Rows[i].HeaderCell.Value.ToString().Equals("0="))
                {
                    rowNum = i;
                    break;
                }
            }
            if (rowNum >= 0)
            {
                for (int i = 1; i < matrix.ColumnCount; i++)
                {
                    if (GetValue(matrix[i, rowNum]) > 0)
                    {
                        colNum = i;
                        break;
                    }
                }
                if (colNum >= 0)
                {
                    Calculate(rowNum, colNum);
                    matrix.Columns.RemoveAt(colNum);

                    MessageLog("Жорданово исключение с клеткой[" + rowNum + "," + colNum + "]");
                }

            }
        }

        private void FindBasePlan() 
        {
            for (int i = 0; i < matrix.RowCount - 1; i++)
            {
                if (GetValue(matrix[0, i]) < 0)
                {
                    for (int j = 0; j < matrix.ColumnCount; j++)
                    {
                        matrix[j, i].Value = -1 * GetValue(pastMatrix[j, i]);
                    }
                }
            }
        }

        private void Optimize() 
        {
            double minColumnVal = 0;//минимальный из элементов целевой функции
            double minRowVal = 0;//минимальное положительное отношение свободного члена к значению в столбце
            int colNum = -1;
            int rowNum = -1;
            bool elemIsFound = false;
            for (int i = 1; i < matrix.ColumnCount; i++) {
                if (GetValue(matrix[i, matrix.RowCount - 1]) < minColumnVal) 
                {
                    colNum = i;
                    minColumnVal = GetValue(matrix[i, matrix.RowCount - 1]);
                }
            }
            for (int i = 0; i < matrix.RowCount - 1; i++) {
                if (GetValue(matrix[colNum, i]) > 0)
                {
                    if (!elemIsFound)
                    {
                        elemIsFound = true;
                        rowNum = i;
                        minRowVal = GetValue(matrix[0, i]) / GetValue(matrix[colNum, i]);
                    }
                    else
                    {
                        rowNum = i;
                        minRowVal = GetValue(matrix[0, i]) / GetValue(matrix[colNum, i]);
                    }
                }
            }
            if (!elemIsFound)
            {
                MessageLog("Нет оптимизации");
            }
            Calculate(rowNum, colNum);
        }

        private bool isBasePlan() 
        {
            bool isBasePlan = true;
            for (int i = 0; i < matrix.RowCount - 1; i++) 
            {
                if (GetValue(matrix[0, i]) < 0)
                {
                    isBasePlan = false;
                    break;
                }
            }
            if (isBasePlan)
            {
                MessageLog("Опорный план");
            }
            else
            {
                MessageLog("Нет опорного плана");
            }
            return isBasePlan;
        }

        private bool isOptimized() 
        {
            bool isOptimized = true;
            for (int i = 1; i < matrix.ColumnCount; i++) {
                if (GetValue(matrix[i, matrix.RowCount - 1]) < 0)
                {
                    isOptimized = false;
                }
            }
            if (isOptimized)
            {
                MessageLog("Оптимизировано");
            }
            else
            {
                MessageLog("Не оптимизировано");
            }
            return isOptimized;
        }

        private void Calculate(int rowNum,int colNum) 
        {
            for (int i = 0; i < matrix.RowCount; i++) 
            {
                for (int j = 0; j < matrix.ColumnCount; j++) 
                {
                    if (i == rowNum && j == colNum)
                    {
                        matrix[j, i].Value = 1 / GetValue(pastMatrix[colNum, rowNum]);
                    }
                    else if (i == rowNum)
                    {
                        matrix[j, i].Value = GetValue(pastMatrix[j, i]) / GetValue(pastMatrix[colNum, rowNum]);
                    }
                    else if (j == colNum)
                    {
                        matrix[j, i].Value = -1*GetValue(pastMatrix[j, i]) / GetValue(pastMatrix[colNum, rowNum]);
                    }
                    else
                    {
                        matrix[j, i].Value =  (GetValue(pastMatrix[j, i]) * GetValue(pastMatrix[colNum,rowNum]) - GetValue(pastMatrix[j,rowNum])*GetValue(pastMatrix[colNum,i]))/GetValue(pastMatrix[colNum,rowNum]);
                    }
                }
            }

            string colHeaderValue = matrix.Columns[colNum].HeaderCell.Value.ToString();
            string rowHeaderValue = matrix.Rows[rowNum].HeaderCell.Value.ToString();
            matrix.Columns[colNum].HeaderCell.Value = "-" + rowHeaderValue;
            matrix.Rows[rowNum].HeaderCell.Value = colHeaderValue.Substring(1);
        }
        private double GetValue(DataGridViewCell cell) 
        {
            return Convert.ToDouble(cell.Value);
        }
        private void MessageLog(string str) {
            logBox.Text += Environment.NewLine;
            logBox.Text += str;
        }

    }
}
