<template>
	<section>
		<div>
			<h2>GET ALL</h2>
			<button @click="getAllDoctors">AllDoctors</button>
			<div v-if="isVisible">
				<ul v-for="doctor in doctors" :key="doctor.id">
					<li>
						ID: {{ doctor.id }} <br />
						FullName: {{ doctor.fullName }} <br />
						Phone: {{ doctor.phone }} <br />
						Specialization: {{ doctor.specialization }}
					</li>
				</ul>
			</div>
		</div>
		<div>
			<h2>CURRENT ID: {{ doctorId }}</h2>
			<input type="text" v-model="doctorId" />
			<button @click="getDoctor">getDoctor</button>
			<p v-if="isValid">
				ID: {{ doctor.id }} <br />
				FullName: {{ doctor.fullName }}
			</p>
			<p v-else>Invalid id!</p>
		</div>
		<div>
			<h2>POST</h2>
			<form @submit.prevent="createDoctor">
				<input
					type="text"
					v-model="newDoctor.firstName"
					placeholder="firstName"
				/>
				<input
					type="text"
					v-model="newDoctor.lastName"
					placeholder="lastName"
				/>
				<input
					type="text"
					v-model="newDoctor.phone"
					placeholder="phoneNumber"
				/>
				<input
					type="text"
					v-model="newDoctor.specialization"
					placeholder="specialization"
				/>
				<button type="submit">Create</button>
			</form>
		</div>
	</section>
</template>

<script>
import axios from "axios";
const API = "https://localhost:44389/api/doctors";

export default {
	data() {
		return {
			isVisible: false,
			isValid: true,
			doctors: [],
			doctor: {},
			doctorId: null,
			newDoctor: {
				firstName: "",
				lastName: "",
				phone: "",
				specialization: "",
			},
		};
	},
	methods: {
		async getAllDoctors() {
			this.isValid = true;
			try {
				await axios.get(API).then((result) => {
					const { data } = result;
					this.doctors = data;
				});
			} catch (error) {
				this.isValid = false;
			}
			this.toggleVisibility();
		},
		async getDoctor() {
			this.isValid = true;
			try {
				await axios.get(`${API}/${this.doctorId}`).then((result) => {
					const { data } = result;
					this.doctor = data;
				});
			} catch (error) {
				this.isValid = false;
			}
			this.doctorId = null;
		},
		async createDoctor() {
			this.isValid = true;
			try {
				await axios.post(API, {
					firstName: this.newDoctor.firstName,
					lastName: this.newDoctor.lastName,
					phone: this.newDoctor.phone,
					specialization: this.newDoctor.specialization,
				});
				this.newDoctor.firstName = "";
				this.newDoctor.lastName = "";
				this.newDoctor.phone = "";
				this.newDoctor.specialization = "";
			} catch (error) {
				this.isValid = false;
			}
		},
		toggleVisibility() {
			this.isVisible = !this.isVisible;
		},
	},
};
</script>

<style>
#app {
	font-family: sans-serif;
	text-align: center;
}
</style>
