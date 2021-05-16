package tech.vofy.notes.objects;

import android.os.Parcel;

import androidx.room.Ignore;

import com.arlib.floatingsearchview.suggestions.model.SearchSuggestion;


public class SearchQueryItem implements SearchSuggestion {
    public int entityId;
    public String name;

    public SearchQueryItem (int entityId, String name) {
        this.entityId = entityId;
        this.name = name;
    }

    @Ignore
    protected SearchQueryItem(Parcel in) {
        entityId = in.readInt();
        name = in.readString();
    }

    @Override
    public String getBody() {
        return name;
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(entityId);
        dest.writeString(name);
    }

    @Ignore
    public static final Creator<SearchQueryItem> CREATOR = new Creator<SearchQueryItem>() {
        @Override
        public SearchQueryItem createFromParcel(Parcel in) {
            return new SearchQueryItem(in);
        }

        @Override
        public SearchQueryItem[] newArray(int size) {
            return new SearchQueryItem[size];
        }
    };
}
