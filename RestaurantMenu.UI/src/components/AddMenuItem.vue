<template>
    <div>
        <h2>Add New Menu Item</h2>

        <form @submit.prevent="addMenuItem">
            <div class="form-group">
                <label for="name">Name:</label>
                <input id="name" v-model="form.name" required/>
            </div>
            <div class="form-group">
                <label for="description">Description:</label>
                <textarea id="description" v-model="form.description" rows="2"></textarea>
            </div>
            <div class="form-group">
                <label for="price">Price (₹):</label>
                <input id="price" type="number" v-model.number="form.price" required />
            </div>
            <div class="form-group">
                <label for="category">Category ID:</label>
                <input id="category" v-model="form.categoryId" />
            </div>
            <button type="submit">Add Item</button>
        </form>
        <p v-if="successMessage" class="success">{{ successMessage }}</p>
        <p v-if="errorMessage" class="error">{{ errorMessage }}</p>
    </div>
</template>
<script>
import api from "../services/api.js";

export default {
  name: "AddMenuItem",
  data() {
    return {
      form: {
        name: "",
        description: "",
        price: null,
        categoryId: ""
      },
      successMessage: "",
      errorMessage: ""
    };
  },
  methods: {
    async addMenuItem() {
      try {
        const response = await api.post("/menu", this.form);
        this.successMessage = `✅ Added: ${response.data.name}`;
        this.errorMessage = "";
        this.form = { name: "", description: "", price: null, categoryId: "" };
      } catch (error) {
        this.errorMessage = "❌ Failed to add item. Check the console.";
        this.successMessage = "";
        console.error("Error adding item:", error);
      }
    }
  }
};
</script>
<style scoped>
.add-menu-item {
  max-width: 600px;
  margin: 2rem auto;
  padding: 1.5rem;
  background: #fafafa;
  border-radius: 12px;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
}

form {
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

input, textarea {
  width: 100%;
  padding: 0.6rem;
  border-radius: 8px;
  border: 1px solid #ccc;
}

button {
  background: #2d8cf0;
  color: white;
  border: none;
  padding: 0.7rem;
  border-radius: 8px;
  cursor: pointer;
}

button:hover {
  background: #1a6dcf;
}

.success {
  color: green;
  margin-top: 1rem;
}

.error {
  color: red;
  margin-top: 1rem;
}
</style>