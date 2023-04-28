package com.max.chocotorta;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;

import com.google.android.material.snackbar.Snackbar;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    private Button btnGuardarLocalidad, btnGuardarUsuario;
    private EditText txtLocalidades, txtNombreUsuario, txtClave, txtRepetirClave, txtCorreo, txtCodigoPostal;
    private Spinner spinnerLocalidades;

    protected void cleanUserFields() {
        txtNombreUsuario.setText("");
        txtClave.setText("");
        txtRepetirClave.setText("");
        txtCorreo.setText("");
        txtCodigoPostal.setText("");
    }

    protected boolean verifyAllCompleted() {
        String nombre = txtNombreUsuario.getText().toString();
        String clave = txtClave.getText().toString();
        String repClave = txtRepetirClave.getText().toString();
        String correo = txtCorreo.getText().toString();
        String codigoPostal = txtCodigoPostal.getText().toString();
        if(nombre.isEmpty()) {
            txtLocalidades.setError("Ingrese un nombre");
            return false;
        }
        if(clave.isEmpty()) {
            txtClave.setError("Ingrese una contraseña");
            return false;
        }
        if(!repClave.equals(clave)) {
            txtRepetirClave.setError("Las contraseñas no coinciden");
            return false;
        }
        if(correo.isEmpty()) {
            txtCorreo.setError("Ingrese un correo");
            return false;
        }
        if(!android.util.Patterns.EMAIL_ADDRESS.matcher(correo).matches()) {
            txtCorreo.setError("Ingrese un correo electrónico válido");
            return false;
        }
        if(codigoPostal.isEmpty()) {
            txtCodigoPostal.setError("Ingrese un código postal");
            return false;
        }
        if(spinnerLocalidades.getSelectedItemPosition() == -1) {
            Snackbar snackbar = Snackbar.make(findViewById(R.id.mainLayout), "Debe seleccionar una localidad", Snackbar.LENGTH_LONG);
            snackbar.show();
            return false;
        }
        return true;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        /* Controles */
        btnGuardarLocalidad = findViewById(R.id.btnGuardarLocalidad);
        btnGuardarUsuario = findViewById(R.id.btnGuardarUsuario);
        txtLocalidades = findViewById(R.id.txtLocalidades);
        txtNombreUsuario = findViewById(R.id.txtNombreUsuario);
        txtClave = findViewById(R.id.txtClave);
        txtRepetirClave = findViewById(R.id.txtRepetirClave);
        txtCorreo = findViewById(R.id.txtCorreo);
        txtCodigoPostal = findViewById(R.id.txtCodigoPostal);
        spinnerLocalidades = findViewById(R.id.spinnerLocalidades);


        List<String> localidades = new ArrayList<String>();
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, localidades);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerLocalidades.setAdapter(adapter);

        btnGuardarLocalidad.setOnClickListener(view -> {
            // Verificamos que el control no esté vacío:
            String nuevaLocalidad = txtLocalidades.getText().toString();
            boolean estaVacio = nuevaLocalidad.isEmpty();
            boolean seRepite = localidades.contains(nuevaLocalidad);
            if(estaVacio) {
                txtLocalidades.setError("Ingrese un valor");
            }
            if(!estaVacio && seRepite) {
                txtLocalidades.setError("El valor ingresado ya existe. Intente con otro");
            }
            if(!estaVacio && !seRepite) {
                // No está vacío y no se repite
                localidades.add(nuevaLocalidad);
                adapter.notifyDataSetChanged();
                txtLocalidades.setText("");
            }
        });
        btnGuardarUsuario.setOnClickListener(view -> {

            if(verifyAllCompleted()) {
                String nombre = txtNombreUsuario.getText().toString();
                String msj = "¡Bienvenido " + nombre + "!";
                Snackbar snackbar = Snackbar.make(findViewById(R.id.mainLayout), msj, Snackbar.LENGTH_LONG);
                snackbar.show();
                cleanUserFields();
            }
        });

    }

}