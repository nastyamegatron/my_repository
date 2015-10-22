package com.example.user.homeworkintent;

import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import java.util.List;

public class ActivityStart extends AppCompatActivity {
    Button mBtnExplicit;
    Button mBtnImplicit;


    //public final int TEXT = 0;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_activity_start);
        mBtnExplicit = (Button)findViewById(R.id.explicit);
        mBtnImplicit = (Button)findViewById(R.id.implicit);


        mBtnExplicit.setOnClickListener(new View.OnClickListener(){
            //static final private int TEXT = 0;

            public void onClick(View v){
                Intent myIntent = new Intent(ActivityStart.this, ActivityResult.class);
                startActivityForResult(myIntent, 0);
            }

        });

        mBtnImplicit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Uri webpage = Uri.parse("http://www.android.com");
                Intent webIntent = new Intent(Intent.ACTION_VIEW, webpage);

                PackageManager packageManager = getPackageManager();
                List activities = packageManager.queryIntentActivities(webIntent,
                        PackageManager.MATCH_DEFAULT_ONLY);
                boolean isIntentSafe = activities.size() > 0;

                if (isIntentSafe) {
                    startActivity(webIntent);
                }
                Intent chooser = Intent.createChooser(webIntent, "through open");

                if (webIntent.resolveActivity(getPackageManager()) != null) {
                    startActivity(chooser);
                }

            }
        });
    }
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        TextView resultTextView = (TextView) findViewById(R.id.textView);

        if (requestCode == 0) {
            if (resultCode == RESULT_OK) {
                String result = data.getStringExtra(ActivityResult.NAME);
                resultTextView.setText(result);
            }else {
                resultTextView.setText("fail");
            }
        }
// ?
        if (requestCode == 1) {
            if (resultCode == RESULT_OK) {
                String result = data.getStringExtra(ActivityResult.NAME);
                resultTextView.setText(result);
            }else {
                resultTextView.setText("fail");
            }
        }

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_activity_start, menu);
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
