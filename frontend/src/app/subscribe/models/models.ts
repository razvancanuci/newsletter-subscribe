export interface Subscriber {
    name: string;
    email: string;
    phoneNumber: string | null;
}

export interface Statistics {
    subscribedLast24H: number;
    subscribedLast7D: number;
    percentageSubscribersWithPhoneNumber: number;
}