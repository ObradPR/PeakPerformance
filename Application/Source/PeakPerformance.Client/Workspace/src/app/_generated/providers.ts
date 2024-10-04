import { Injectable } from '@angular/core';
import { IEnumProvider } from './interfaces';

@Injectable({ providedIn: 'root' }) export class Providers
{
	getInjuryTypes() : IEnumProvider[]
	{
		return [
		    { id: 0, name: 'NotSet', description: '' },
		    { id: 1, name: 'KneeInjury', description: 'Knee Injury' },
		    { id: 2, name: 'ShoulderInjury', description: 'Shoulder Injury' },
		    { id: 3, name: 'BackInjury', description: 'Back Injury' },
		    { id: 4, name: 'ElbowInjury', description: 'Elbow Injury' },
		    { id: 5, name: 'WristInjury', description: 'Wrist Injury' },
		    { id: 6, name: 'AnkleInjury', description: 'Ankle Injury' },
		    { id: 7, name: 'HipInjury', description: 'Hip Injury' },
		    { id: 8, name: 'NeckInjury', description: 'Neck Injury' },
		    { id: 9, name: 'Asthma', description: 'Asthma' },
		    { id: 10, name: 'HeartCondition', description: 'Heart Condition' },
		    { id: 11, name: 'Diabetes', description: 'Diabetes' },
		    { id: 12, name: 'Arthritis', description: 'Arthritis' },
		    { id: 13, name: 'HighBloodPressure', description: 'High Blood Pressure' },
		    { id: 14, name: 'LowBloodPressure', description: 'Low Blood Pressure' },
		    { id: 15, name: 'Pregnancy', description: 'Pregnancy' },
		    { id: 16, name: 'ChronicFatigue', description: 'Chronic Fatigue' },
		    { id: 17, name: 'Scoliosis', description: 'Scoliosis' },
		    { id: 18, name: 'PlantarFasciitis', description: 'Plantar Fasciitis' },
		    { id: 19, name: 'Tendinitis', description: 'Tendinitis' },
		    { id: 20, name: 'CarpalTunnelSyndrome', description: 'Carpal Tunnel Syndrome' },
		    { id: 21, name: 'ChestInjury', description: 'Chest Injury' },
		    { id: 22, name: 'BicepInjury', description: 'Bicep Injury' },
		    { id: 23, name: 'TricepInjury', description: 'Tricep Injury' },
		    { id: 24, name: 'QuadInjury', description: 'Quad Injury' },
		    { id: 25, name: 'HamstringInjury', description: 'Hamstring Injury' }
		];
	}
	getMeasurementUnits() : IEnumProvider[]
	{
		return [
		    { id: 0, name: 'NotSet', description: '' },
		    { id: 1, name: 'Kilograms', description: 'kg' },
		    { id: 2, name: 'Pounds', description: 'lbs' },
		    { id: 3, name: 'Centimeters', description: 'cm' },
		    { id: 4, name: 'Inches', description: 'in' }
		];
	}
	getSocialMediaPlatforms() : IEnumProvider[]
	{
		return [
		    { id: 0, name: 'NotSet', description: '' },
		    { id: 1, name: 'Facebook', description: 'Facebook' },
		    { id: 2, name: 'Twitter', description: 'Twitter' },
		    { id: 3, name: 'Instagram', description: 'Instagram' },
		    { id: 4, name: 'LinkedIn', description: 'LinkedIn' },
		    { id: 5, name: 'YouTube', description: 'YouTube' },
		    { id: 6, name: 'TikTok', description: 'TikTok' },
		    { id: 7, name: 'Pinterest', description: 'Pinterest' },
		    { id: 8, name: 'Snapchat', description: 'Snapchat' },
		    { id: 9, name: 'WhatsApp', description: 'WhatsApp' },
		    { id: 10, name: 'Telegram', description: 'Telegram' },
		    { id: 11, name: 'Reddit', description: 'Reddit' }
		];
	}
	getTrainingGoals() : IEnumProvider[]
	{
		return [
		    { id: 0, name: 'NotSet', description: '' },
		    { id: 1, name: 'Strength', description: 'Strength' },
		    { id: 2, name: 'Bulking', description: 'Bulking' },
		    { id: 3, name: 'Cutting', description: 'Cutting' },
		    { id: 4, name: 'Cardio', description: 'Cardio' },
		    { id: 5, name: 'Explosivness', description: 'Explosivness' },
		    { id: 6, name: 'Endurance', description: 'Endurance' },
		    { id: 7, name: 'Flexibility', description: 'Flexibility' },
		    { id: 8, name: 'Balance', description: 'Balance' },
		    { id: 9, name: 'Agility', description: 'Agility' }
		];
	}
}
