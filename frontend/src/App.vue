<template>
	<section>
		<div>
			<h2>GET ALL</h2>
			<button @click="getAllDoctors">AllDoctors</button>
			<div v-if="isValid">
				<ul v-for="doctor in doctors" :key="doctor.id">
					<li>
						ID: {{ doctor.id }} <br />
						FullName: {{ doctor.fullName }}
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
	</section>
</template>

<script>
import axios from "axios";
const API = "https://localhost:44389/api/doctors";

export default {
	data() {
		return {
			isValid: true,
			doctors: [],
			doctor: {},
			doctorId: null,
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
	},
};
</script>

<style>
#app {
	font-family: sans-serif;
	text-align: center;
}
</style>
