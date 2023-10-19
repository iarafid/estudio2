﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estudio
{
    class Turma
    {
        private double  hora;
        private string professor, dia_semana, modalidade;

        public string Professor { get => professor; set => professor = value; }
        public string Dia_semana { get => dia_semana; set => dia_semana = value; }
        public double Hora { get => hora; set => hora = value; }
        public string Modalidade { get => modalidade; set => modalidade = value; }

        public Turma(string modalidade, string professor, string dia_semana, double hora)
        {
            this.modalidade = modalidade;
            this.professor = professor;
            this.dia_semana = dia_semana;
            this.hora = hora;
        }

        public Turma(string modalidade)
        {
            this.modalidade = modalidade;
        }

        public Turma(string modalidade, string dia_semana)
        {
            this.modalidade = modalidade;
            this.dia_semana = dia_semana;
        }

 


        public Turma()
        {

        }

        public bool cadastrarTurma(string professor, string dia_semana, double hora, string modalidade)
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Turma(professorTurma, diaSemana, horaTurma, modalidadeTurma) values ('" + professor + "','" + dia_semana + "','" + hora + "','" + modalidade + "')", DAO_Conexao.con);
                insere.ExecuteNonQuery();
                cad = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return cad;

        }

        public bool excluirTurma(string modalidade)
        {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("update Estudio_Turma set ativa=1 where modalidadeTurma = '" + modalidade + "'", DAO_Conexao.con);
                exclui.ExecuteNonQuery();
                exc = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                estudio.DAO_Conexao.con.Close();
            }
            return exc;

        }

        public Boolean consultarTurma(string modalidade)
        {
            bool existe = false;

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consultaBool = new MySqlCommand("SELECT * FROM Estudio_Turma WHERE modalidadeTurma = '" + modalidade + "'", DAO_Conexao.con);
                MySqlDataReader resultado = consultaBool.ExecuteReader();
                if (resultado.Read())
                {
                    existe = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                DAO_Conexao.con.Close();
            }

            return existe;

        }

        public MySqlDataReader consultarTurma01()
        {
            MySqlCommand consulta01 = null;
            MySqlDataReader resultado01 = null;

            try
            {
                DAO_Conexao.con.Open();
                consulta01 = new MySqlCommand("SELECT * FROM Estudio_Turma", DAO_Conexao.con);
                resultado01 = consulta01.ExecuteReader();


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }

            finally
            {


            }
            return resultado01;

        }

        public bool atualizaTurma(
            )
        {
            bool updated = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand update = new MySqlCommand("update Estudio_Turma set horaTurma='" + hora +  ", diaSemana=" + dia_semana + ", modalidadeTurma=" + modalidade + ", professorTurma=" + professor + " where modalidade='" + modalidade + "'", DAO_Conexao.con);
                update.ExecuteNonQuery();
                updated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return updated;
        }
    }



}