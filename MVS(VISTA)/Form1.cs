﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace MVS_VISTA_
{
    public partial class Form1 : Form
    {
        ClsContacto objContacto = null;
        ClsContactoMgr objContactoMgr = null;
        DataTable Dtt;

        public Form1()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 1;
            objContactoMgr = new ClsContactoMgr(objContacto);

            Dtt = new DataTable();
            Dtt = objContactoMgr.Listar();
            if (Dtt.Rows.Count > 0)
            {
                dtregistros.DataSource = Dtt;
            }
        }

        private void Guardar()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 2;
            objContacto.Cedula = Convert.ToInt32(txtcedula.Text);
            objContacto.Nombre = txtnombre.Text;
            objContacto.Apellido = txtapellido.Text;
            objContacto.FechaNacimiento = dtpfecha.Value;
            objContacto.Cargo = Convert.ToInt32(txtcargo.Text);

            objContactoMgr = new ClsContactoMgr(objContacto);
            objContactoMgr.GuardarDatos();
            MessageBox.Show("Contacto Guardado Correctamente", "Mensaje");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listar();
            btncambios.Enabled = false;
            btneliminar.Enabled = false;

        }

        private void btnguardar_Click_1(object sender, EventArgs e)
        {
            Guardar();
            Listar();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtcedula.Clear();
            txtnombre.Clear();
            txtapellido.Clear();
           // dtpfecha.Value.Clear();
            txtcargo.Clear();
            txtcedula.Focus();
        }

        private void GuardarCambios()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 3;
            objContacto.Cedula = Convert.ToInt32(txtcedula.Text);
            objContacto.Nombre = txtnombre.Text;
            objContacto.Apellido = txtapellido.Text;
            objContacto.FechaNacimiento = dtpfecha.Value;
            objContacto.Cargo = Convert.ToInt32(txtcargo.Text);

            objContactoMgr = new ClsContactoMgr(objContacto);
            objContactoMgr.GuardarDatos();
            MessageBox.Show("Cambios Guardados Exitosamente", "Mensaje");
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            Listar();
            btnguardar.Enabled = true;
            btncambios.Enabled = false;
            txtcedula.Enabled = true;
            btneliminar.Enabled = false;
            LimpiarCampos();
        }

        


       
        private void dtregistros_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtcedula.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[0].Value.ToString();
            txtnombre.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[1].Value.ToString();
            txtapellido.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[2].Value.ToString();
            txtcargo.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[4].Value.ToString();
           // dtpfecha.Value.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[3].Value.ToString();

            btnguardar.Enabled = false;
            btncambios.Enabled = true;
            txtcedula.Enabled = false;
            btneliminar.Enabled = true;
        }

        private void btncambios_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            Listar();
            LimpiarCampos();


            btnguardar.Enabled = true;
            btncambios.Enabled = false;
            txtcedula.Enabled = true;
            btneliminar.Enabled = false;
            LimpiarCampos();
        }


        public void Eliminar()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 4;
            objContacto.Cedula = Convert.ToInt32(txtcedula.Text);
            objContactoMgr = new ClsContactoMgr(objContacto);

            objContactoMgr.ElinminarDatos();
            MessageBox.Show("Datos Eliminados Exitosamente", "Mensaje");
        }

        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            Eliminar();
            Listar();
            btnguardar.Enabled = true;
            btncambios.Enabled = false;
            txtcedula.Enabled = true;
            btneliminar.Enabled = false;
            LimpiarCampos();
        }

       


       

      

       

       

       
    }
}
