package com.example.user.homeworkintent;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class ActivityResult extends AppCompatActivity {
    Button mBtnResult;
    EditText editText;
    public final static String NAME = "result";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_activity_result);
        mBtnResult = (Button)findViewById(R.id.result);
        editText = (EditText)findViewById(R.id.editText);

        mBtnResult.setOnClickListener(new View.OnClickListener() {
           // public final static String NAME = "result";

            public void onClick(View v) {
            Intent resultIntent = new Intent();
            resultIntent.putExtra(NAME, editText.getText().toString());

            setResult(RESULT_OK, resultIntent);
            finish();
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_activity_result, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
