## Databinding
### Activity

`Activity` `protected void onCreate(Bundle savedInstanceState)`
```diff
@Override
protected void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
-   setContentView(R.layout.activity_main);
+   DataBindingUtil.setContentView(this, R.layout.activity_main);
}
```

### Fragment
`Fragment` `public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState)`
```diff
@Override
public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
-   return inflater.inflate(R.layout.blank_fragment, container, false);
+   return DataBindingUtil.inflate(getLayoutInflater(), R.layout.blank_fragment, container, false).getRoot();
}
```
