<template>
    <!-- Modal Overlay -->
    <div
    v-if="showModal"
    class="fixed inset-0 bg-black/50 flex items-center justify-center z-50"
    >
    <div class="bg-white rounded-xl shadow-lg w-full max-w-md p-6 relative">
        <h2 class="text-xl font-semibold text-gray-800 mb-4">Edit Menu Item</h2>

        <div class="space-y-3">
        <div>
            <label class="block text-sm font-medium text-gray-700">Name</label>
            <input v-model="selectedItem.name" type="text" class="w-full border rounded-lg p-2 mt-1 focus:ring-2 focus:ring-amber-400 focus:outline-none" />
        </div>

        <div>
            <label class="block text-sm font-medium text-gray-700">Description</label>
            <textarea v-model="selectedItem.description" class="w-full border rounded-lg p-2 mt-1 focus:ring-2 focus:ring-amber-400 focus:outline-none"></textarea>
        </div>

        <div>
            <label class="block text-sm font-medium text-gray-700">Price</label>
            <input v-model="selectedItem.price" type="number" class="w-full border rounded-lg p-2 mt-1 focus:ring-2 focus:ring-amber-400 focus:outline-none" />
        </div>
        </div>

        <div class="flex justify-end mt-6 space-x-3">
        <button
            @click="closeModal"
            class="px-4 py-2 rounded-lg bg-gray-100 text-gray-600 hover:bg-gray-200"
        >
            Cancel
        </button>
        <button
            @click="saveEdit"
            class="px-4 py-2 rounded-lg bg-amber-500 text-white hover:bg-amber-600"
        >
            Save
        </button>
        </div>
    </div>
    </div>
    <div class="min-h-screen bg-gray-50">
        <div class="max-w-6xl mx-auto px-4 py-10">
            <h1 lass="text-3xl font-bold text-gray-800 mb-6 text-center">🍴 Restaurant Menu</h1>
        </div>
        <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
            <div v-for= "item in menuItems" :key="item.id" class="bg-white shadow-md rounded-2xl p-5 border border-gray-100 hover:shadow-lg transition-all">
                <h2 class="text-xl font-semibold text-gray-800 mb-2">{{ item.name }}</h2>
                <p class="text-gray-500 mb-3">{{ item.description }}</p>
                <p class="text-lg font-bold text-amber-600 mb-4">₹{{ item.price.toFixed(2) }}</p>
                <div class="flex justify-between">
                    <button @click="openEdit(item)" class="px-3 py-1 rounded-lg bg-blue-100 text-blue-700 hover:bg-blue-200 transition"> Edit</button>
                    <button @click="deleteItem(item.id)" class="px-3 py-1 rounded-lg bg-blue-100 text-blue-700 hover:bg-blue-200 transition">Delete</button>   
                </div>
                
            </div>
        </div>
    
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

<script setup>
import { ref } from 'vue'
import axios from 'axios'

const menuItems = ref([])
const selectedItem = ref(null)
const showModal = ref(false)

const fetchMenu = async () => {
  const res = await axios.get('http://localhost:5188/api/menu')
  menuItems.value = res.data
}

const openEdit = (item) => {
  selectedItem.value = { ...item }
  showModal.value = true
}

const closeModal = () => {
  showModal.value = false
  selectedItem.value = null
}

const saveEdit = async () => {
  await axios.put(`http://localhost:5188/api/menu/${selectedItem.value.id}`, selectedItem.value)
  await fetchMenu()
  closeModal()
}

fetchMenu()
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