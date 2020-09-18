import { Platform } from "./commons";

export type Game = {
    id: number;
    title: string;
    platform: Platform;
}

export type Genre = {
    id: number;
    name: string;
}

export type Record = {
    id: number;
    name: string;
    age: number;
    insertedAt: string;
}