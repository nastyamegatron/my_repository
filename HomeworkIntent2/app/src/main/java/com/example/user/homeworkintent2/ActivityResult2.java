package com.example.user.homeworkintent2;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class ActivityResult2 extends AppCompatActivity {
    Button mBtnResult;
    public final static String NAME = "result";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_activity_result2);
        mBtnResult = (Button)findViewById(R.id.result);
        final TextView text = (TextView)findViewById(R.id.textView);

        mBtnResult.setOnClickListener(new View.OnClickListener() {


            public void onClick(View v) {
                Intent webIntent = new Intent();
                String str = getIntent().getDataString();
                //getIntent().getDataString();
                text.setText(str);



            }
        });
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_activity_result2, menu);
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
