
typedef struct {
    int key;
    int value;
} ht_item;

typedef struct {
    int size;
    int count;
    ht_item** items;
} ht_hash_table;



ht_hash_table* ht_new();
void ht_del_hash_table(ht_hash_table* ht);
void ht_insert(ht_hash_table* ht, const int key, const int value);
int ht_search(ht_hash_table* ht, const int key);
void ht_delete(ht_hash_table* h, const int key);
void ht_print(ht_hash_table* h);