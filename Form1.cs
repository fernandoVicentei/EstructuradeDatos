using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace RECURSIVO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Vector v = new Vector();
        Matriz mm = new Matriz();
        Algoritmos a = new Algoritmos();
        Cola c = new Cola();
        private void button1_Click(object sender, EventArgs e)
        {

        }
        int dim1;
        int dim2;
        int dimcola=0;
        int[] vec;
        int[,] m;
        int[] vecCola;        
        ArrayList ee = new ArrayList();
        
        private void mOSTRARVECTORToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // ee.Add(new int[2, 2]);
            //ee[0][0,0]=9;
            
            //MessageBox.Show("["+  +"]");

            dim1 = int.Parse(this.textBox1.Text);
            vec = new int[dim1];
            v.cargarv(ref vec,dim1);
            dataGridView1.Rows.Clear();
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = dim1;
            v.mostrar(vec, dim1, ref dataGridView1);
        }

        private void mOSTRARMATRIZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dim1 = int.Parse(this.textBox1.Text);
            dim2 = int.Parse(this.textBox2.Text);
            m = new int[dim1, dim2];
            mm.cargarm(ref m, dim1 - 1, dim2 - 1);
            dataGridView1.Rows.Clear();
            dataGridView1.RowCount = dim1;
            dataGridView1.ColumnCount = dim2;
            mm.mostrar(m, dim1 - 1, dim2 - 1,ref dataGridView1);
        }

        private void nUMEROPRIMOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dim1 = int.Parse(this.textBox1.Text);
            if (a.primo(dim1,1)<=2)
            {
                this.textBox3.Text = " EL NUMERO [" + dim1 + "] ES PRIMO";
            }
            else
            {
                this.textBox3.Text = " EL NUMERO [" + dim1 + "] NO  ES PRIMO";
            }
        }
       

        private void nUMEROSPRIMOSDE1ANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dim1 = int.Parse(this.textBox1.Text);
            string ret = a.primosrango(dim1);
            this.textBox3.Text = ret.ToString();
        }
        ListaSimple lista = new ListaSimple();
        ListaDoble lisdoble = new ListaDoble();
        ListaDobleExamen Listaexamen = new ListaDobleExamen();
        Pila pilita = new Pila();
        Arbol arbol = new Arbol();
        private void eLEMENTOSPRIMOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text!=" ")
            {        
                dataGridView1.Rows.Clear();
                dataGridView1.RowCount = 1;
                dataGridView1.ColumnCount = dim1;
                v.primosvect(vec, dim1-1, ref dataGridView1);
            }
        }

        private void eLEMENTOSPRIMOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.RowCount = dim1;
            dataGridView1.ColumnCount = dim2;
            mm.primosmatriz(m, dim1-1, dim2-1, ref dataGridView1);
        }

        private void eLEMENTOSENPOSICIONPARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = dim1;
            v.elementposicionpar(vec, dim1-1, ref dataGridView1);
        }

        private void cAGRGFDFDToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cARGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dimcola += 1;
            if (dimcola==1)
            {
                vecCola = new int[dimcola];
                vecCola = c.recrearVector(ref vecCola,dimcola);
            }
            else
            {
                vecCola = c.recrearVector(ref vecCola, dimcola);
            }
            MessageBox.Show("Nuevo nodo Agregado");
            textBox3.Text = c.retornarColas(vecCola, dimcola);


        }

        private void mOSTRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cola = c.retornarColas(vecCola, dimcola);
            this.textBox3.Text = cola.ToString();
        }

        private void sACARNODOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nodo = "";
            c.sacarnodo(ref vecCola, dimcola,ref nodo);
            MessageBox.Show("Nodo Sacado "+nodo+"");            
            dimcola -= 1;
            textBox3.Text = c.retornarColas(vecCola, dimcola);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aGREGARNUEVOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = Interaction.InputBox("NOMBRE", "NUEVO ", "", 50, 50);
            string genero = Interaction.InputBox("GENERO", "NUEVO ", "", 50, 50);
            int edad = int.Parse(Interaction.InputBox("EDAD", "NUEVO ", "", 50, 50));
            int ci=int.Parse( Interaction.InputBox("CI", " NUEVO ", "", 50, 50));
            lista.Agregar(nombre, ci, edad, genero);
        }

        private void bUSCARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int edad = int.Parse(Interaction.InputBox("EDAD", "BUSCAR POR EDAD ", "", 50, 50));
            string re = lista.buscarxEdad(edad);
            this.textBox3.Text = re.ToString();
        }

        private void aGREGARPALABRAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pal = Interaction.InputBox("AGREGAR PALABRA", "ES PALINDROME ?", "", 50, 50);
            for (int i = 0; i < pal.Length; i++)
            {
                pilita.AgregarNodo(pal.Substring(i, 1));
            }
            MessageBox.Show("PALABRA AGREGADA");
            string retorno=pilita.Mostrar();
            if (retorno == pal)
            {
                MessageBox.Show("LA PALABRA ES PALINDROME"+ retorno+" == "+pal);
            }
            else
                MessageBox.Show("LA PALABRA NO ES PALINDROME " + pal+" != "+retorno );
        }

        private void eCUACIONFORMALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pal = Interaction.InputBox("AGREGAR PALABRA", "ES PALINDROME ?", "", 50, 50);
            for (int i = 0; i < pal.Length; i++)
            {
                pilita.AgregarNodo(pal.Substring(i, 1));
            }
            MessageBox.Show("PALABRA AGREGADA");
            MessageBox.Show("" + pilita.MostrarCorreccionE());           
           
        }

        private void cOLAHOSPITALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = Interaction.InputBox("NOMBRE", "NUEVO ", "", 50, 50);
            string genero =  Interaction.InputBox("GENERO", "NUEVO ", "", 50, 50);
            c.CargarPaciente(nombre, genero);
        }

        private void dIVIDIRCOLAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c.DividirCola();
        }
        private void mOSTRARDIVISIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = c.mostrardivision();
        }

        private void nUEVONODOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int vect =int.Parse( Interaction.InputBox("INGRESAR LONGITUD DE VECTOR", "AGREGAR VECTOR", "", 50, 50));
            string[] cade = new string[vect];
            for (int i = 0; i < vect; i++)
            {
                cade[i] = Interaction.InputBox("AGREGAR CADENA", "LLENANDO VECTOR", "", 50, 50);
            }
            int fi = int.Parse(Interaction.InputBox("INGRESAR LONGITUD DE FILAS", "AGREGAR MATRIZ", "", 50, 50));
            int co = int.Parse(Interaction.InputBox("INGRESAR LONGITUD DE COLUMNAS", "AGREGAR MATRIZ", "", 50, 50));
            int[,] mat = new int[fi,co];

            for (int i = 0; i < fi; i++)
            {
                for (int J = 0; J < co; J++)
                    mat[i,J]=int.Parse( Interaction.InputBox("INGRESAR NUMEROS", "LLENANDO MATRIZ", "", 50, 50));

            }
            lisdoble.Agregarnodo(mat, cade);
        }

        private void mOSTRARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lisdoble.Mostrar(ref dataGridView1);
        }

        private void nODOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int valor = int.Parse(Interaction.InputBox("INGRESAR VALOR","VALOR","",50,50));
            arbol.AgregarNodo(valor);
        }

        private void mOSTRARToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string valor = "";
            arbol.MostrarInOrden( ref valor);
        }

        private void oRDENARVECTORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = dim1;
            v.OrdenarVector(vec,dim1,ref dataGridView1);
        }

        private void nUEVONODOEXAMENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int vect = int.Parse(Interaction.InputBox("INGRESAR LONGITUD DE VECTOR", "AGREGAR VECTOR", "", 50, 50));
            int[] vecto = new int[vect];
            for (int i = 0; i < vect; i++)
            {
                vecto[i] =int.Parse( Interaction.InputBox("AGREGAR CADENA", "LLENANDO VECTOR", "", 50, 50));
            }
            int fi = int.Parse(Interaction.InputBox("INGRESAR LONGITUD DE FILAS", "AGREGAR MATRIZ", "", 50, 50));
            int co = int.Parse(Interaction.InputBox("INGRESAR LONGITUD DE COLUMNAS", "AGREGAR MATRIZ", "", 50, 50));
            int[,] mat = new int[fi, co];

            for (int i = 0; i < fi; i++)
            {
                for (int J = 0; J < co; J++)
                    mat[i, J] = int.Parse(Interaction.InputBox("INGRESAR NUMEROS", "LLENANDO MATRIZ", "", 50, 50));

            }
            MatrixValor mati = new MatrixValor();
            VectorValor vec = new VectorValor();
            vec.Vector = vecto;
            mati.Matriz = mat;

            Listaexamen.Agregarnodo(mati, vec);
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            indice -= 1;
            Listaexamen.Mostrar(ref dataGridView1, ref indice, ref textBox3);
        }
        int indice = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            indice += 1;
            Listaexamen.Mostrar(ref dataGridView1,ref indice, ref textBox3);

        }

        private void mOSTRAREXAMENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("HOLA MUNDO");
        }
    }
    class Arbol
    {
        NodoArbol nodito;
        NodoArbol copia;
        public Arbol()
        {
            nodito = null;
            copia = null;
        }
        public void AgregarNodo(int valor1)
        {
            NodoArbol nuevo = new NodoArbol();
            nuevo.Valor = valor1;
            bool encontrado = false;
            if (nodito==null)
            {
                nodito = nuevo;
                nodito.HijoI = null;
                nodito.HijoD = null;
            }
            else
            {
                NodoArbol actor = nodito;

                while (encontrado!=true)
                {
                    
                        if (valor1 > actor.Valor)
                        {
                            if (actor.HijoD != null)
                            {
                                actor = actor.HijoD;
                            }
                            else
                            {
                                actor.HijoD = nuevo;
                                encontrado = true;
                            }                           
                        }
                        else
                        {
                            if (actor.HijoI != null)
                            {
                                actor = actor.HijoI;
                            }
                            else
                            {
                                actor.HijoI = nuevo;
                                encontrado = true;
                            }
                            
                        }              
                                   

                }
                
            }
            copia = nodito;            
        }
        public void mostrar(  NodoArbol copia, ref string dat)
        {
            if (copia != null)
            {
                dat += " " + copia.Valor;
                if (copia.HijoI != null)
                {
                    
                   mostrar( copia.HijoI,ref dat);
                    /*copia = copia.HijoI;
                    MostrarInOrden(ref rdato);*/
                }
                if (copia.HijoD != null)
                {
                    mostrar(copia.HijoD, ref dat);
                    //return copia.Valor + " " + mostrar( copia.HijoD);
                  /*  copia = copia.HijoD;
                    MostrarInOrden(ref rdato);*/
                }                
            }            
        }
        public void MostrarInOrden(ref string rdato)
        {
            NodoArbol bbb = nodito;
            string da = "";
            mostrar( bbb,ref da);
            MessageBox.Show(" " + da + " ");
        }


    }

    class NodoArbol
    {
        NodoArbol hijoderecha;
        NodoArbol hijoizquierda;
        public int valor;

        public NodoArbol HijoD
        {
            get { return hijoderecha; }
            set { hijoderecha = value; }
        }
        public NodoArbol HijoI
        {
            get { return hijoizquierda; }
            set { hijoizquierda = value; }
        }
        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }


    }


    class ListaSimple
    {
        NodoLista nodito= new NodoLista();
        public ListaSimple()
        {
            nodito = null;
        }

        public void Agregar(string nombre,int ci,int edad,string genero)
        {
            NodoLista nuevo = new NodoLista();
            nuevo.Edad = edad;
            nuevo.CI = ci;
            nuevo.Nombre = nombre;
            nuevo.Genero = genero;           
            if (nodito == null)
            {
                nodito = nuevo;
                nodito.NodoPost = null;
            }
            else
            {
                NodoLista cc = nodito;
                while (cc.NodoPost != null)
                {
                    cc = cc.NodoPost;
                }
                cc.NodoPost = nuevo;
            }
            MessageBox.Show("Usuario " + nombre + " Agregado");
        }

        public string buscarxEdad(int edad)
        {
            NodoLista nuevo = nodito;
            string retorno = "";
            while (nuevo.NodoPost!=null)
            {
                if (nuevo.Edad == edad)
                {
                    retorno += String.Format("[{0}][{1}][{2}][{3}]\n",nuevo.CI,nuevo.Nombre,nuevo.Edad,nuevo.Genero);
                }
                nuevo = nuevo.NodoPost;
            }
            return retorno;
        }
    }

    class ListaDoble
    {
        NodoDoble noddoble;

        public ListaDoble()
        {
            noddoble = null;
        }

        public void Agregarnodo(int[,]mat,string[] cadenas)
        {
            NodoDoble nuevo = new NodoDoble();
            nuevo.Cadenas = cadenas;
            nuevo.Matriz = mat;
            if (noddoble == null)
            {
                noddoble = nuevo;
                noddoble.Indice = 1;
                noddoble.Izquierda = nuevo;
                nuevo.Derecha = noddoble;
            }
            else
            {
                int auxi2 = 1;
                NodoDoble auxi = noddoble;
                if (auxi.Derecha!=null)
                {
                    do
                    {
                        auxi2 = auxi.Indice;
                        auxi = auxi.Derecha;
                    } while (auxi.Indice != noddoble.Indice);
                }
                nuevo.Indice = auxi2 + 1;
                NodoDoble AUXIS = auxi.Izquierda;
                nuevo.Izquierda = AUXIS;
                
                AUXIS.Derecha = nuevo;
                nuevo.Derecha = auxi;
                noddoble.Izquierda = nuevo;

                /*nuevo.Derecha = auxi;
                auxi.Derecha = nuevo;
                nuevo.Indice = auxi2 + 1;
                noddoble.Izquierda = nuevo;
                nuevo.Izquierda =AUXIS;         */     
                
            }

            MessageBox.Show("NODO AGREGADO");
        }
        public void Mostrar(ref DataGridView d)
        {
            NodoDoble auxi = noddoble;
            int col = noddoble.Izquierda.indice;
            d.RowCount = 2;
            d.ColumnCount = col;
            int celda = 0;
            if (auxi.Derecha != null)
            {
                do
                {
                    int[,] postizo = auxi.Matriz;
                    string[] postizo2 = auxi.Cadenas;
                    string num = "";
                    string cadena = "";
                    for (int i = 0; i < postizo.GetLength(0); i++)
                    {
                        for (int j = 0; j < postizo.GetLength(1); j++)
                            num += " " + postizo[i, j];                        
                    }
                    for (int i = 0; i < postizo2.Length; i++)
                    {
                        cadena += " " + postizo2[i] + "\n";
                    }
                    d.Rows[0].Cells[celda].Value = num;
                    d.Rows[1].Cells[celda].Value =cadena;
                    cadena = "";
                    num = "";
                    celda++;
                    auxi = auxi.Derecha;
                } while (auxi != noddoble);
            }
        }
    }

    class NodoDoble
    {
        public string[] vec;
        public int indice;
        public int[,] mat;
        NodoDoble izquierda;
        NodoDoble derecha;
        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }
        public NodoDoble Izquierda
        {
            get { return izquierda; }
            set { izquierda = value; }
        }
        public NodoDoble Derecha
        {
            get { return derecha; }
            set { derecha = value; }
        }
        public string[] Cadenas
        {
            get { return vec; }
            set { vec = value; }
        }

        public int[,] Matriz
        {
            get { return mat; }
            set { mat = value; }
        }


    }
    class ListaDobleExamen
    {
        NodoDobleExamen noddoble;
        public ListaDobleExamen()
        {
            noddoble = null;
        }

        public void Agregarnodo(MatrixValor mat,VectorValor vect)
        {
            NodoDobleExamen nuevo = new NodoDobleExamen();
            nuevo.Vector = vect;
            nuevo.Matriz = mat;

            if (noddoble == null)
            {
                noddoble = nuevo;
                noddoble.Indice = 1;
                noddoble.Izquierda = nuevo;
                nuevo.Derecha = noddoble;
            }
            else
            {
                int auxi2 = 1;
                NodoDobleExamen auxi = noddoble;
                if (auxi.Derecha != null)
                {
                    do
                    {
                        auxi2 = auxi.Indice;
                        auxi = auxi.Derecha;
                    } while (auxi.Indice != noddoble.Indice);
                }
                nuevo.Indice = auxi2 + 1;
                NodoDobleExamen AUXIS = auxi.Izquierda;
                nuevo.Izquierda = AUXIS;

                AUXIS.Derecha = nuevo;
                nuevo.Derecha = auxi;
                noddoble.Izquierda = nuevo;
            }
            MessageBox.Show("NODO AGREGADO DESDE EL CODIGO DE GIT");
        }
        public void Mostrar(ref DataGridView d,ref int indice, ref TextBox bb)
        {
            NodoDobleExamen auxi = noddoble;
            int col = noddoble.Izquierda.indice;            
            int celda = 0;
            bool encontrado = false;
            if (indice < 1)
            {
                indice = col;
            }else if (indice>col)
            {
                indice = 1;
            }

            if (auxi.Derecha != null)
            {
                do
                {
                    if (indice == auxi.Indice)
                    {
                        int[,] postizo = auxi.Matriz.Matriz;
                        int[] postizo2 = auxi.Vector.Vector;

                        d.RowCount = postizo.GetLength(0);
                        d.ColumnCount = postizo.GetLength(1);
                        string cadena = "";
                        for (int i = 0; i < postizo.GetLength(0); i++)
                        {
                            for (int j = 0; j < postizo.GetLength(1); j++)
                            {
                                if (postizo.GetLength(1) - i == j + 1)
                                {
                                   d.Rows[i].Cells[j].Style.BackColor = Color.Cyan;
                                    d.Rows[i].Cells[j].Value = postizo[i, j];
                                }
                                else
                                {
                                    d.Rows[i].Cells[j].Value = postizo[i, j];
                                }
                            }                               
                              
                        }
                        int aux = 0;
                        for (int i = 0; i < postizo2.Length; i++)
                        {
                            for (int j = i + 1; j < postizo2.Length; j++)
                            {
                                if (postizo2[i] > postizo2[j])
                                {
                                    aux = postizo2[j];
                                    postizo2[j] = postizo2[i];
                                    postizo2[i] = aux;
                                }
                            }
                            
                            
                        }
                        for (int i = 0; i < postizo2.Length; i++)
                        {
                            cadena += " " + postizo2[i] + "\n";
                        }
                        bb.Text = cadena.ToString();
                        encontrado = true;
                    }                         
                 
                   
                    auxi = auxi.Derecha;
                } while (encontrado!=true ||auxi != noddoble);
              

            }
        }
        
    }

    class NodoDobleExamen
    {
        MatrixValor mat;
        VectorValor vect;
        public int indice;
    
        NodoDobleExamen izquierda;
        NodoDobleExamen derecha;
        public NodoDobleExamen()
        {
            mat = null;
            vect = null;
            izquierda = null;
            derecha = null;
            indice = 0;
        }
        public MatrixValor Matriz
        {
            get { return mat; }
            set { mat = value; }
        }
        public VectorValor Vector
        {
            get { return vect; }
            set { vect = value; }
        }
        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }
        public NodoDobleExamen Izquierda
        {
            get { return izquierda; }
            set { izquierda = value; }
        }
        public NodoDobleExamen Derecha
        {
            get { return derecha; }
            set { derecha = value; }
        }        
    }


    class MatrixValor
    {
        int[,] mat;

        public  int[,] Matriz
        {
            get { return mat; }
            set { mat = value; }
        }
    }
    class VectorValor
    {
        int[] vect;

        public int[] Vector
        {
            get { return vect; }
            set { vect = value; }
        }
    }

    class NodoLista
    {
        public string nombre;
        public int ci;
        public int edad;
        public string genero;
        public NodoLista nodoposterior;
        
        public NodoLista NodoPost
        {
            get { return nodoposterior; }
            set { nodoposterior = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public int CI
        {
            get { return ci; }
            set { ci = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

    }

    class Cola
    {
        NodoCola tope;
        NodoCola hombre;
        NodoCola Mujeres;
       
        public Cola()
        {
            tope = null;
            hombre = null;
            Mujeres = null;
        }


        public void CargarPaciente(string nombre,string genero)
        {
            NodoCola nuevo = new NodoCola();
            nuevo.Genero = genero;
            nuevo.Nombre = nombre;

            if(tope==null)
            {
                tope = nuevo;
                tope.Posterior = null;
            }
            else
            {
                NodoCola cc = tope;
                while (cc.Posterior != null)
                {
                    cc = cc.Posterior;
                }
                cc.Posterior = nuevo;
            }
            MessageBox.Show("PACIENTE EN LA COLA");

        }
        public void AgregarGenero(string nombre,string genero,ref NodoCola sexo)
        {
            NodoCola nuevo = new NodoCola();
            nuevo.Genero = genero;
            nuevo.Nombre = nombre;

            if (sexo==null)
            {
                sexo = nuevo;
                sexo.Posterior = null;
            }
            else
            {
                NodoCola cc = sexo;
                while (cc.Posterior != null)
                {
                    cc = cc.Posterior;
                }
                cc.Posterior = nuevo;
            }
        }
        public void DividirCola()
        {
            NodoCola copia = tope;
            Mujeres = null;
            hombre = null;

            while (copia!=null)
            {
                if (copia.Genero=="M")
                {
                    AgregarGenero(copia.Nombre,copia.Genero,ref Mujeres);
                }
                else
                {
                    AgregarGenero(copia.Nombre, copia.Genero, ref hombre);
                }
                copia = copia.Posterior;
            }
            MessageBox.Show("COLA DIVIDIDA EN DOS");
        }

        public string mostrardivision()
        {
            string cadena = "HOMBRES\n\n";
            while (hombre!=null)
            {
                cadena+="["+hombre.Nombre+","+hombre.Genero+"]\n";
                hombre = hombre.Posterior;
            }
            cadena += "MUEJRES\n\n";
            while (Mujeres!=null)
            {
                cadena += "[" + Mujeres.Nombre + "," +Mujeres.Genero + "]\n";
                Mujeres = Mujeres.Posterior;
            }
            return cadena;

        }
        public int[] recrearVector(ref int[] vec,int dim)
        {
            int[] vecAux = new int[dim];
            for (int i = 0; i <dim-1; i++)
            {
                vecAux[i] = vec[i];
            }
            //cargamos el nuevo valor del ultimo dato
            vecAux[dim - 1] = int.Parse(Interaction.InputBox("INGRESAR NUEVO NODO","NODO NUEVO","",50,50));
            return vecAux;
        }
        public string retornarColas(int[] vec, int dim)
        {
            string cadena = "";
            if (dim == 0)
            {                
                return "Cola Vacia";
            }
            else
            {
                for (int i = 0; i < dim; i++)
                {
                    cadena += "[" + vec[i] + "]";
                }
                return cadena;
            }           
        }
        public void sacarnodo(ref int[] vec,int dim,ref string cad)
        {
            if (dim<=0)
            {
                MessageBox.Show("Cola vacia");

            }
            else
            {
                int[] vecaux = new int[dim - 1];
                for (int i = 1; i < dim; i++)
                {
                    vecaux[i - 1] = vec[i];
                }

                cad = "[" + vec[0] + "]";
                vec = vecaux;
            }
           
        }
    }
    
    class NodoCola
    {
        public string nombre;
        public string genero;
        public NodoCola siguiente;

        public NodoCola Posterior
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
        
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }


    }

    class Algoritmos
    {
        public int primo(int numero, int aux)
        {
            if (aux == numero)
            {
                return 1;
            }
            else
            {
                return (numero % aux == 0 ? 1 : 0) + primo(numero, aux + 1);
            }
        }
        public string primosrango(int numero)
        {
            if (numero == 1)
            {
                return "[" + numero + "]";
            }
            else
            {
                return (primo(numero, 1) <= 2 ? "[" + numero + "]" : "") + " " + primosrango(numero - 1);
            }
        }
    }
    class Matriz
    {
        Algoritmos aaa = new Algoritmos();
        public void cargarm(ref int[,] m,int dim1,int dim2)
        {
            if (dim1<0)
            {

            }
            else
            {
                if (dim2 >= 0)
                {
                    m[dim1,dim2] = int.Parse(Interaction.InputBox("INGRESAR ", "DATOS", "", 50, 50));
                    cargarm(ref m, dim1, dim2 - 1);
                }
                else
                {
                    cargarm(ref m, dim1 - 1, m.GetLength(1)-1);
                }
            }
        }
        public void mostrar(int[,] m, int dim1, int dim2,ref DataGridView b)
        {
            if (dim1 < 0)
            {

            }
            else
            {
                if (dim2 >= 0 )
                {
                    b.Rows[dim1].Cells[dim2].Value=m[dim1, dim2];
                    mostrar( m, dim1, dim2 - 1,ref b);
                }
                else
                {
                    mostrar(m, dim1 - 1, m.GetLength(1) - 1,ref b);
                }
            }

        }

        public void primosmatriz(int[,] m, int dim1, int dim2, ref DataGridView b)
        {
           
            if (dim2 >= 0)
            {
                if (aaa.primo(m[dim1, dim2],1) <= 2)
                {
                    b.Rows[dim1].Cells[dim2].Style.BackColor = Color.Aqua;
                }
                b.Rows[dim1].Cells[dim2].Value = m[dim1, dim2];
                primosmatriz(m, dim1, dim2 - 1, ref b);
            }
            else if(dim1>0)
            {
                primosmatriz(m, dim1 - 1, m.GetLength(1) - 1, ref b);
            }
            else { }
            
        }
    }
    class Vector
    {
        Algoritmos aA = new Algoritmos();
        public void mostrar( int[] v, int dim,ref DataGridView b) { 
            if(dim==0){
            
                b.Rows[0].Cells[dim].Value = v[dim];
            }
            else
            {
                b.Rows[0].Cells[dim-1].Value = v[dim-1];
                mostrar(v, dim - 1, ref b);
            }
        }
        public void cargarv(ref int[] v,int dim)
        {
            if (dim == 0)
            {
                v[dim] = int.Parse(Interaction.InputBox("INGRESAR ","DATOS","",50,50));
            }
            else
            {
                v[dim-1] = int.Parse(Interaction.InputBox("INGRESAR ", "DATOS", "", 50, 50));
                cargarv(ref v,dim - 1);
            }
        }
        public void primosvect(int[] v, int dim, ref DataGridView b)
        {
            if (dim == -1)
            {
            }
            else
            {
                if (aA.primo(v[dim],1)<=2)
                {
                    b.Rows[0].Cells[dim].Style.BackColor = Color.Aqua;                                       
                }              
                b.Rows[0].Cells[dim].Value = v[dim];
                primosvect(v, dim - 1, ref b);
            }
        }

        public void elementposicionpar(int[] v, int dim, ref DataGridView b)
        {
            if (dim == 0)
            {
                b.Rows[0].Cells[dim].Value = v[dim];
            }
            else
            {
                if (dim%2==0)
                {
                    b.Rows[0].Cells[dim].Style.BackColor = Color.Aqua;
                }
                b.Rows[0].Cells[dim].Value = v[dim];
                elementposicionpar(v, dim - 1, ref b);
            }
        }

        public void OrdenarVector(int[] v,int dim,ref DataGridView b)
        {
            int aux = 0;
            for (int i = 0; i < dim; i++)
            {
            
                for (int j = i+1; j < dim; j++)
                {
                    if (v[i]>v[j])
                    {
                        aux = v[j];
                        v[j] = v[i];
                        v[i] = aux;
                    }
                }
            }
            for (int i = 0; i <dim; i++)
            {
                b.Rows[0].Cells[i].Value = v[i];
            }
        }
    }

    class Pila
    {
        NodoPila nodo;
        NodoPila actor;
        public Pila()
        {
            nodo = null;
            actor = nodo;
        }

        public void AgregarNodo(string valor)
        {
            NodoPila nuevo = new NodoPila();
            nuevo.Valor = valor;
            nuevo.Siguiente = nodo;
            nodo = nuevo;
            actor = nodo;

        }
        
        public string Mostrar()
        {
            string rt = "";
            if (actor != null)
            {
                rt += "" + actor.Valor;
                actor = actor.Siguiente;
                return rt+""+Mostrar();
            }
            nodo = null;
            return rt;
            
        }

        public string MostrarCorreccionE()
        {
            NodoPila actor = nodo;
            int corchete=0, parentesis=0, llaves = 0;
            while (actor!=null)
            {
                if (actor.Valor == "{"||actor.Valor=="("||actor.Valor=="[")
                {
                    if (actor.Valor == "{")
                        llaves++;
                    else if (actor.Valor == "[")
                        corchete++;
                    else
                        parentesis++;
                }
                else
                {
                    if (actor.Valor == "}")
                        llaves--;
                    else if (actor.Valor == "]")
                        corchete--;
                    else if(actor.Valor==")")
                        parentesis--;
                }
                 
                actor = actor.Siguiente;
            }
            string cadenacorrecion = "";
            if (llaves==0)
            {
                cadenacorrecion += "LLAVES CORRECTOS\n";
            }
            else
            {
                cadenacorrecion += "LLAVES FALTAN CERRARSE\n";
            }
            if (corchete == 0)
            {
                cadenacorrecion += "CORCHETES CORRECTOS\n";
            }
            else
            {
                cadenacorrecion += "CORCHETES FALTAN CERRARSE\n";
            }
            if (parentesis == 0)
            {
                cadenacorrecion += "PARENTESIS CORRECTOS\n";
            }
            else
            {
                cadenacorrecion += "PARENTESIS INCORRECTOS\n";
            }
            return cadenacorrecion;
        }
    }
    class NodoPila
    {
        public string valor;
        public NodoPila siguiente;

        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public NodoPila Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
    }

}
