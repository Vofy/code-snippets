package com.example.databindingexample.ui.main;

import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

public class MainViewModel extends ViewModel {
    public MutableLiveData<String> text = new MutableLiveData<>();

    public MainViewModel() {
        text.setValue("Nastaveno konstruktorem");
    }
}