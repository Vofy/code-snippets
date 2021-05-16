package tech.vofy.notes.objects;

public class DeletedObject<DeletedObjectType> {
    private int position;
    private DeletedObjectType deletedObject;

    public DeletedObject(int position, DeletedObjectType deletedObject) {
        this.position = position;
        this.deletedObject = deletedObject;
    }

    public int getPosition() {
        return position;
    }

    public DeletedObjectType getObject() {
        return deletedObject;
    }
}
