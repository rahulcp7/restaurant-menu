<template>
    <div class="min-h-screen bg-gray-50">
        <div class="max-w-6xl mx-auto px-4 py-10">
            <h1 lass="text-3xl font-bold text-gray-800 mb-6 text-center">Restaurant Menu</h1>
        </div>
        
        <router-link to="/add" class="btn"> Add New Item</router-link>
        <ul>
            <li v-for= "item in menuItems" :key="item.id">
                <strong>{{ item.name }} — ₹{{ item.price }}</strong>
                <p>{{ item.description }}</p>

                <button @click="editItem(item)"> Edit</button>
                <button @click="deleteItem(item.id)">Delete</button>
            </li>
        </ul>
    
        <div v-if="editingItem" class="edit-form">
            <h3>Edit Item</h3>
            <form @submit.prevent="updateItem">
                <input v-model="editingItem.name" placeholder="Name" required/>
                <input v-model.number="editingItem.price" placeholder="Price" type="number" required />
                <textarea v-model="editingItem.description" placeholder="Description"></textarea>
                <button class="bg-blue-500 hover:bg-blue-600 text-white px-3 py-1 rounded">Save</button>
                <button @click="cancelEdit" type="button">Cancel</button>
            </form>
        </div>
    </div>
</template>

<script>
import api from "../services/api";

export default {
  data() {
    return {
      menuItems: [],
      editingItem: null,
    };
  },
  methods: {
    async fetchMenu() {
      const response = await api.get("/menu");
      this.menuItems = response.data;
    },
    editItem(item) {
      this.editingItem = { ...item }; // Clone object
    },
    cancelEdit() {
      this.editingItem = null;
    },
    async updateItem() {
      await api.put(`/menu/${this.editingItem.id}`, this.editingItem);
      this.editingItem = null;
      await this.fetchMenu();
    },
    async deleteItem(id) {
      if (confirm("Are you sure you want to delete this item?")) {
        await api.delete(`/menu/${id}`);
        await this.fetchMenu();
      }
    },
  },
  mounted() {
    this.fetchMenu();
  },
};
</script>

<style scoped>
.menu-list {
  max-width: 600px;
  margin: 2rem auto;
}
button {
  margin: 4px;
}
</style>